    Random rnd = new Random();
    while (list.Count < 6)
    {
        int randnum = rnd.Next(1, 49); // creates a number between 1 and 49
        if (!list.Contains(randnum))
        {
            list.Add(randnum);
        }
        else
        {
            //duplicate number
        }
    }
