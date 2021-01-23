    string errormessage="Please enter a positive number; previous input was invalid";
            Console.WriteLine("Enter the number: ");
            int k = Convert.ToInt32(Console.ReadLine());
            while (k < 0)
            {
                Console.Write(errormessage);
                //get back to the input line
                Console.SetCursorPosition(0, Console.CursorTop-1);
                //Clearing the previous input
                for (int i = 0; i < k.ToString().Length; i++)
                    Console.Write(" ");
                Console.Write("\r");
                k = Convert.ToInt32(Console.ReadLine());
            }
            //Clearing the error message
            for (int i = 0; i < errormessage.Length; i++)
                Console.Write(" ");
            Console.WriteLine("\r");
