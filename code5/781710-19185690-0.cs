    {
            double A, B, C, D;
            Console.WriteLine("input Four Numbers and Press Enter after each.");
            A = Convert.ToDouble(Console.ReadLine());
            B = Convert.ToDouble(Console.ReadLine());
            C = Convert.ToDouble(Console.ReadLine());
            D = Convert.ToDouble(Console.ReadLine());
            double[] values = { A, B, C, D };
            Array.Sort(values);
            int count = 0;
            foreach (double value in values)
            {
                Console.Write(value + " ");
                if (count != values.Length - 1)
                {
                    Console.Write("< ");
                }
                count++;
            }
