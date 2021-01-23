    int arrayLength = 0;
    int timesindex = line.IndexOf("TIMES"); 
    if (timesindex > 0)
    {
        string[] items = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        if (int.TryParse(items[items.Length - 2], out occursCount)) 
        {
            arrayLength = occursCount;
        }
    }
