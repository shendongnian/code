    if(object.Time > 0 && <= 499)
    {
         rate = .75m
    }
    else if(object.Time >= 500 && <= 999)
    {
         rate = .85m
    }
    else if(object.Time >= 1000)
    {
         rate = 1.00m
    }
    else
    {
         rate = 0m;
    }
