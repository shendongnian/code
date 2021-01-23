    decimal amount = 0;
    
    if (decimal.TryParse(entry.Split('$')[0], out amount))
    {
        string nameSplit = entry.Split('.', ':')[1].Trim();
        if (names.ContainsKey(nameSplit))
        {
            names[nameSplit] += amount;
            Console.WriteLine("Hoozah!");
        }
        else
        {
            names.Add(nameSplit, amount);
            Console.WriteLine("Failure");
        }
    }
    else
    {
        // the input file has an invalid line, do something about it
    }
