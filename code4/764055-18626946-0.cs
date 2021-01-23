                int[] values;
            Seperate(inputNumber, out values);
            Console.Write("{0},{1},{2},{3}", values[0] / 1000, values[1], values[2], values[3]);
            Console.ReadKey();
        }
        public static void Seperate(string numbers, out int[] values)
        {
            values = new int[numbers.Length];
            for (int x = 0; x <= numbers.Length - 1; x++)
            {
                values[x] = int.Parse(numbers[x].ToString());
            }
        }
