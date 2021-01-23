        int i = 0;
        int[]values = new int[10];
        while(i < values.Length)
        {
            Console.WriteLine("Please enter a number: ");
            int result;
            string input = Console.ReadLine();
            if(Int32.TryParse(input, out result)
            {
                values[i] = result;
                i++;
            }
            else
            { 
                Console.WriteLine("Not a valid integer");
            }
        }
