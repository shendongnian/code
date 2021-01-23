    List<decimal> numlist = new List<decimal>();
    
    numlist.Add(50.2m);
    numlist.Add(40.6m);
    numlist.Add(9.0m);
    
    decimal diff = 100.0m - numlist.Sum();
    //This is set because the value should be only 1 decimal place
    int update = Convert.ToInt32(diff / .1m);
    if (update > 0)
    {
        for (int x = 0; x < update; x++)
        {
            numlist[x % numlist.Count()] += .1m;
        }
    }
    else
    {
        for (int x = 0; x < Math.Abs(update); x++)
        {
            numlist[x % numlist.Count()] -= .1m;
        }
    }
