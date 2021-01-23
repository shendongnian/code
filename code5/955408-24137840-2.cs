    string[] split = new string[] {","};
    string[] lines = File.ReadAllLines(filename);
    int rows = lines.Length;
    int cols = lines[0].Split(split, StringSplitOptions.RemoveEmptyEntries).Count();
    currentMap = new int[rows,cols];
    for (int row = 0; row < rows + 1; row++)
    {
          string line = lines(row);
          string[] result = line.Split(split, StringSplitOptions.None);
          int col = 0;
          foreach (string s in result)
          {
               int value;
               Int32.TryParse(s, out value)
               currentMap[row, col] = value;
               col++;
          }
     }
