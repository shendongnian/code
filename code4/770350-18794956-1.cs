        static void Main(string[] args)
        {
            List<Item> myItems = new List<Item>();
            List<string> myFile = File.ReadAllLines("C:\\Path\\Values.txt").ToList();
            foreach (string value in myFile)
            {
                switch(value.Substring(0,4))
                {
                    case "1001":
                        myItems.Add(MyParseMethod1(value));
                        break;
                    case "1002":
                        myItems.Add(MyParseMethod2(value));
                        break;
                    default:
                        myItems.Add(MyDefaultParser(value));
                        break;
                }
            }
        }
        public static Item MyParseMethod1(string stringIWishtoParse)
        {
            Item myItem = new Item();
            //Parse string, set object values
            //myItem.Attribute1 = whatever portion you want from your string
            return myItem;
        }
        public static Item MyParseMethod2(string stringIWishtoParse)
        {
            Item myItem = new Item();
            //Parse string, set object values
            //myItem.Attribute1 = whatever portion you want from your string
            return myItem;
        }
        public static Item MyDefaultParser(string stringIWishtoParse)
        {
            //Follow pattern from other methods
        }
    }
