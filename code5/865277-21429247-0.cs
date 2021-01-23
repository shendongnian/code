    int custNUmber;
    long l;
    if(long.TryParse(FinalValue, out l))
    {
        if(l < int.MinValue || l > int.MaxValue)
        {
            // log
        }
        else
        {
            custNUmber = (int)l;
        }
    }
    else
    {
        // not a number
    }
