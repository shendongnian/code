            bool c =false;
            string[,] Arr = new string[,]{
                {"A1" , "A2" , "A3" , "A4" , "A5"},
                {"B1" , "B2" , "B3" , "B4" , "B5"}};
            Console.Write("Input: ");
            string input = Console.ReadLine();
            foreach (String temp in Arr)
            {
                c = input.Equals(temp);
                if (c)
                    break;
            }
            if (c)
                Console.Write("Your input is on the array.");
            else
                Console.Write("Your input is not on the array.");
            Console.ReadLine();
        }
