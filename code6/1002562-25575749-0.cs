            Console.Write("Write a number: ");
            int Number = 0;
            try
            {
                Number = Convert.ToInt32(Console.ReadLine());
            }
            catch ( OverflowException )
            {
                Console.WriteLine("Number to big");
            }
            TellLastNumber(Number);
