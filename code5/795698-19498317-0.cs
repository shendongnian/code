    private static void Main()
        {
            using (var reader = new StreamReader("filename"))
            {
                var tileSizeX = Convert.ToInt32(reader.ReadLine());
                var tileSizeY = Convert.ToInt32(reader.ReadLine());
                var mapSizeX = Convert.ToInt32(reader.ReadLine());
                var mapSizeY = Convert.ToInt32(reader.ReadLine());
                char[,] map = new char[mapSizeX, mapSizeY];
                for (var i = 0; i < mapSizeY; i++)
                {
                    string line = reader.ReadLine();
                    for (int j = 0; j < mapSizeX; j++)
                    {
                        map[j, i] = line[j];
                    }
                }
                for (int i = 0; i < mapSizeX; i++)
                {
                    for (int j = 0; j < mapSizeY; j++)
                    {
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }
