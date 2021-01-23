    class Program {
        #region lambda shortcuts
        static Action<object> Warn = m => {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(m);
        };
        static Action<object> Info = m => {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(m);
        };
        static Action<object> WriteQuery = m => {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(m);
        };
        static Action BreakLine = Console.WriteLine;
        #endregion
    
        static void Main(string[] args) {
            Console.Title = "The Dice Game";
            while(true) {
                bool @continue = RunDiceGame();
                if(!@continue) {
                    break;
                }
                Console.Clear();
            }
        }
    
        static bool RunDiceGame() {
            //Display Introduction and Instructions
            Info("Welcome To The Dice Game!");
            Info("This Program will simulate rolling a dice and keeps track of the results");
            BreakLine();
    
            WriteQuery("Dice roll count: ");
            int rollCount = ReadInt32();
    
            WriteQuery("Random number generator seed: ");
            Random rng = new Random(ReadInt32());
    
            BreakLine();
            BreakLine();
    
            //map dice value to dice count
            var diceValues = new Dictionary<int, int>((int)rollCount);
            for(int i = 0; i < 6; i++) {
                diceValues.Add(i, 0);
            }
       
            //roll dice
            for(int i = 0; i < rollCount; i++) {
                int diceValue = rng.Next(6); //roll 0..5
                diceValues[diceValue]++;
            }
    
            //print results
            for(int i = 0; i < 6; i++) {
                int valueRollAbsolute = diceValues[i];
                double valueRollCountRelative = valueRollAbsolute / (double) rollCount;
                Info(string.Format("Value: {0}\tCount: {1:0,0}\tPercentage: {2:0%}", i + 1, valueRollAbsolute, valueRollCountRelative));
            }
    
            BreakLine();
            BreakLine();
    
            WriteQuery("Type 'yes' to restart, 'no' to exit.");
            BreakLine();
            return ReadYesNo();
        }
    
        #region console read methods
        static int ReadInt32() {
            while(true) {
                string input = Console.ReadLine();
                try {
                    return Convert.ToInt32(input);
                } catch(FormatException) {
                    Warn("Not a number: " + input);
                }
            }
        }
    
        static bool ReadYesNo() {
            while(true) {
                string option = Console.ReadLine();
                switch(option.ToLowerInvariant()) {
                    case "yes":
                        return true;
                    case "no":
                        return false;
                    default:
                        Warn("Invalid option: " + option);
                        break;
                }
            }
        }
        #endregion
    }
