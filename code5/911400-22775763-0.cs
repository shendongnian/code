           do
            {
                Console.Write("Enter the amount of donuts purchased -> ");
                Int.TryParse(Console.ReadLine(), out number_Of_Donuts);
                if (number_Of_Donuts < 0)
                    Console.WriteLine("Invalid input, number of donuts must be positive");
            } while (number_Of_Donuts <= 0);
