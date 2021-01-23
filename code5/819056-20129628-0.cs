        public static string[,] GetData(int row, int column, string filePath)
        {
            int[,] data = new string[row, column];
            using (StreamReader reader = File.OpenText(filePath))
            {
                for (int r = 0; r < data.GetLength(0); r++)
                {
                    for (int c = 0; c < data.GetLength(1); c++)
                    {
                        if (reader.EndOfStream)
                        {
                            return data;
                        }
                        data[r, c] = int.Parse(reader.ReadLine());
                    }
                }
            }
            return data;
        }
