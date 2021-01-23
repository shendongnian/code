        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            Random ran = new Random();
            int number = 0;
            int min = 1;
            int max = 51;
            for (int i = 0; i < 50; i++)
            {
                do
                {
                    number = ran.Next(min, max);
                }
                while (numbers.Contains(number));
                numbers.Add(number);
                if (number == min) min++;
                if (number == max - 1) max--;
            }
            for (int i = 0; i < 50; i++)
                Console.WriteLine(numbers[i]);
            Console.ReadKey();
        }
