using System;


namespace BoredGame{

    class Timer{

        public static DateTime getTime(){
            return DateTime.Now;
        }



        public static TimeSpan timeDiffT(DateTime start, DateTime end){    
            return end.Subtract(start);
        }
    }

    class Program{

        static void Main(string[] args){

            bool running = true;
            Program prog = new Program();

            Console.WriteLine("i heard you're bored?\n");


            DateTime startTime = Timer.getTime();
            Boolean asking = true;
            string[] options = ["yes i am", "no im not", "who's asking"];
            string[] answers = ["bored", "fine", "suspicious"];
            int userOption = 0;
            string selectedColour = "\u001b[32m";
            string escapeColour = "\u001b[0m";
            (int x, int y) = Console.GetCursorPosition();
            ConsoleKeyInfo keyPress;

            while (asking){

                Console.SetCursorPosition(x, y);

                for (int i = 0; i < options.Length; i++){
                    if (userOption == i){
                        Console.WriteLine(selectedColour + options[i] + escapeColour);
                    }
                    else Console.WriteLine(options[i] + escapeColour);
                }

                keyPress = Console.ReadKey(true);

                switch (keyPress.Key){
                    case ConsoleKey.DownArrow:
                        userOption++;
                        if(userOption > 2){
                            userOption = 0;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        userOption--;
                        if(userOption < 0){
                            userOption = 2;
                        }
                        break;
                    case ConsoleKey.Enter:
                        asking = false;
                        break;
                }

            }

            Console.WriteLine($"\nyou are {answers[userOption]}");

            DateTime endTime = Timer.getTime();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"it took you {Timer.timeDiffT(startTime, endTime).ToString(@"mm\:ss\.ff")} to answer...");

            Console.ResetColor();

            Console.WriteLine("now what?");

        }

    }
}



