     string[] fileLines = File.ReadAllLines(path);
            int[,] map = new int[fileLines.Length,fileLines[0].Split(',').Length];
            for (int i = 0; i < fileLines.Length; ++i)
            {
                string line = fileLines[i];
                for (int j = 0; j < map.GetLength(1); ++j)
                {
                    string[] split = line.Split(',');
                    map[i, j] = Convert.ToInt32(split[j]);
                }
            }
            return map;
        }
