        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("duom.txt");
            string[][] grid = new string[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                grid[i] = lines[i].Split(',');
            }
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < **grid**[i].Length; j++)
                {
                    Console.WriteLine(grid[i][j]);
                    Console.ReadLine();
                }
            }
        }
