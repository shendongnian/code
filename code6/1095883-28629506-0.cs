            bool isInvalid, isOutOfRange;
            decimal balance = 0;
            isOutOfRange = true;
            do
            {
                string input = Console.ReadLine();
                
                isInvalid = !Decimal.TryParse(input, out balance);
                if (!isInvalid)
                {
                    isOutOfRange = (balance <= 1 || balance > 1000000);
                }
                if (isInvalid || isOutOfRange)
                {
                    Console.WriteLine("Please enter a valid decimal value: $");
                }
            } while (isInvalid || isOutOfRange);
            Console.WriteLine("{0}, That is a valid value!", balance.ToString());
            Console.ReadKey();
