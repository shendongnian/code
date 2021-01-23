    int rows = 10; int columns = 5;
    List<List<string>> lines = new List<List<string>>(rows);
    for (int row = 1; row <= rows; row++)
    {
        List<string> fields = new List<string>(columns);
        for (int col = 1; col <= columns; col++)
            fields.Add(string.Format("row{0},col{1}", row, col));
        lines.Add(fields);
    }
