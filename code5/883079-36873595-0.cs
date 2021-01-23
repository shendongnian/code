            string letter2 = AskuserforInput("second letter");
            string number2 = SwitchMethod(letter2);
            string letter3 = AskuserforInput("third letter");
            string number3 = SwitchMethod(letter3);
            string letter4 = AskuserforInput("fouth letter");
            string number4 = SwitchMethod(letter4);
            string letter5 = AskuserforInput("fifth letter");
            string number5 = SwitchMethod(letter5);
            string letter6 = AskuserforInput("sixth letter");
            string number6 = SwitchMethod(letter6);
            string letter7 = AskuserforInput("seventh letter");
            string number7 = SwitchMethod(letter7);
            string letter8 = AskuserforInput("eigth letter");
            string number8 = SwitchMethod(letter8);
            string letter9 = AskuserforInput("ninth letter");
            string number9 = SwitchMethod(letter9);
            string letter10 = AskuserforInput("tenth letter");
            string number10 = SwitchMethod(letter10);
            //declaring strings
            
            Console.WriteLine("This is the original letter phone digits");
            Console.WriteLine("({0}{1}{2})) {3}{4}{5} - {6}{7}{8}{9} ", letter1,letter2, letter3, letter4, letter5, letter6, letter7, letter8, letter9, letter10);//continue this
           
            
            Console.WriteLine("The actual numbers" );
            Console.WriteLine("({0}{1}{2})) {3}{4}{5} - {6}{7}{8}{9} ", number1, number2, number3, number4, number5, number6, number7, number8, number9, number10);//continue this
            Console.Read();
            #region End Program
            //wait for program to acknowledge results
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\nPlease hit ENTER to end program. . .");
            Console.Read();
            #endregion
            Console.Read();
            //also pulled this back up from a previous program
        }
        public static string SwitchMethod(string x)
        {
            string y = "*";
            switch (x)
            {
                case "0":
                    y = "0";
                    break;
                case "1":
                    y = "1";
                    break;
                case "A":
                case "a":
                case "B":
                case "b":
                case "C":
                case "c":
                case "2":
                    y = "2";
                    break;
                case "D":
                case "d":
                case "E":
                case "e":
                case "F":
                case "f":
                case "3":
                    y = "3";
                    break;
                case "G":
                case "g":
                case "H":
                case "h":
                case "I":
                case "i":
                case "4":
                    y = "4";
                    break;
                case "J":
                case "j":
                case "K":
                case "k":
                case "L":
                case "l":
                case "5":
                   y = "5";
                    break;
                case "M":
                case "m":
                case "N":
                case "n":
                case "O":
                case "o":
                case "6":
                    y = "6";
                    break;
                case "P":
                case "p":
                case "Q":
                case "q":
                case "R":
                case "r":
                case "S":
                case "s":
                case "7":
                    y = "7";
                    break;
               
                case "T":
                case "t":
                case "U":
                case "u":
                case "V":
                case "v":
                case "8":
                    y = "8";
                    break;
                case "W":
                case "w":
                case "X":
                case "x":
                case "Y":
                case "y":
                case "Z":
                case "z":
                case "9":
                    y ="9";
                    break;
                default:
                    Console.WriteLine("knucklehead, not a letter");
                    Console.WriteLine("an '*' will show up");
                    break;
                    //used cases, next will use to.lower
                    //Lynch helped
            
            }
            return y;
       
        }
        public static string AskuserforInput(string x)
        {
            Console.WriteLine("\nPlease type {0}", x);
            String input = Console.ReadLine();
            return input;
            
