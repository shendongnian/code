            Console.WriteLine("Enter your SSN:");
            string SSN = Console.ReadLine();
            int[] SSN_numbers = new int[3];
            try
            {
                String[] numbers = SSN.Split('-');
                if (numbers.Length != 3) throw new Exception("SSN is not in correct format!");
                for (int i = 0; i != 3; i++)
                {
                    SSN_numbers[i] = Convert.ToInt32(numbers[i]);
                }
                // do what you want with your numbers here...
                Console.WriteLine("first number: {0}", SSN_numbers[0]);
                Console.WriteLine("second number: {0}", SSN_numbers[1]);
                Console.WriteLine("third number: {0}", SSN_numbers[2]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("SSN is not in correct format!");
            }
        
