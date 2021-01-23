            Console.WriteLine("Enter length of arrays (three dimensions, comma separated)");
            string line = Console.ReadLine();
            string[] stringDimensions = line.Split(',');
            int[] intDimensions = stringDimensions.Select(s => Convert.ToInt32(s)).ToArray();
            var array = new string[intDimensions[0],intDimensions[1],intDimensions[2]];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i, j, k] = String.Format("{0}.{1}.{2}", i, j, k);
                    }
                }
            }
