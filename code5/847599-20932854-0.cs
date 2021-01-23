    foreach (string l in lines)
    {
        string[] split = l.Split(',');
        foreach (string item in split)
        {
            head[row, column] = item;
            column++;
        }
        row++;
        column = 0;
    }
    for (row = 1; row < 4; row++)
    {
        for (column = 1; column < 4; column++)
        {
            string rowAndColumn = head[row, 0] + head[0, column];
            string value = string.IsNullOrEmpty(head[row, column]) ? "0" : head[row, column];
            listBox1.Items.Add(rowAndColumn + value);
        }
    }
