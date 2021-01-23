    int sum = 0;
    string[] tokens = str.Split(delim);
    foreach(string str in tokens)
    {
        int value = 0;
        if (int.TryParse(str, out value))
        {
            sum += value;
        }
    }
