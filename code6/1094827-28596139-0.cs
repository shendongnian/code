     List<string> numbersInput = new List<string>();
            Console.WriteLine("Please enter an integer");
            string input = Console.ReadLine();
            while (!String.IsNullOrEmpty(input))
            {
                Console.WriteLine("Please enter another integer: ");
               input = Console.ReadLine();
            }
            if (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("The number you have entered is: " + " " + input);
                numbersInput.Add(input);
                foreach (string value in numbersInput)
                {
                    Console.WriteLine("The number that was added to the list is : " + " " + value);
                }
                Console.ReadLine();
            }
