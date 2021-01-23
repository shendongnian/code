    public static void Main(string[] args)
    {
        List<int> validInputs = new List<int>();
        for (int counter = 0; counter <= 10; counter++)
        {
            Console.Write("Enter a number: ");
            string stringInput = Console.ReadLine();
            
            int numberInput;
            if (int.TryParse(stringInput, out numberInput))
            {
                if ((10 <= numberInput && numberInput <= 100) &&
                    validInputs.Contains(numberInput) == false)
                {
                    Console.WriteLine("Number is valid");
                    validInputs.Add(numberInput);
                }
                else
                {
                    // This is not a valid number cause it's not in the range or it's a duplicate
                    Console.WriteLine("Invalid number");
                    counter--;
                }
            }
            else
            {
                // This is not a valid number
                Console.WriteLine("Invalid number");
                counter--;
            }
        }
    }
