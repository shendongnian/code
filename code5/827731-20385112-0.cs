    foreach (string line in File.ReadLines(Path))
    {  
        string [] column = line.Split(',');
        if (column.Count() >= 5 && column.id == column[4])
        {
            return false;
        }
    }
