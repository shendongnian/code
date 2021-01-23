    string name, desc, date;
    if (input.Length >= 4)
    {
        name = input.Substring(0, 4);
        if (input.Length >= 10)
        {
            desc = input.Substring(4, 6);
            if (input.Length >= 14)
            {
                date = input.Substring(10, 4);
            }
        }
    }
