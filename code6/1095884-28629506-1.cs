            bool isInvalid, isOutOfRange;
            decimal balance = 0;
            isOutOfRange = true;
            do
            {
                string input = Console.ReadLine();
                isInvalid = !Decimal.TryParse(input, out balance);
                if (!isInvalid)
                {
                    // use balance<=1 if 1 should not be included
                    // use balance>=1000000 if 1000000 should not be included
                    isOutOfRange = (balance < 1 || balance > 1000000);
                }
                if (isInvalid)
                {
                    Console.WriteLine("Please enter a valid decimal value: $");
                }
                else if (isOutOfRange)
                {
                    Console.WriteLine("Please enter value between 1 and 1000000: $");
                }
            } while (isInvalid || isOutOfRange);
            Console.WriteLine("{0}, That is a valid value!", balance.ToString());
            Console.ReadKey();
