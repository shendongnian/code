        static void Main(string[] args)
        {
            foreach (int element in Factors(16))
            {
                Console.Write(element.ToString() + ", ");
            }
        }
        static Array Factors(double value)
        {
            int[] factors = new int[Convert.ToInt32(Math.Round(value,0))];
            int counter = 0;
            for (int i = 1; i <= value; i++)
            {
                if (value % i == 0)
                {
                    factors[counter] = i;
                    counter++;
                }
            }
            Array.Resize(ref factors, counter);
            return factors;
        }
