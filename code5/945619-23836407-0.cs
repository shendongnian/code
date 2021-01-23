    bool doBigCall = false;
    if (test1)
    {
        if (test2)
        {
            doBigCall = true;
        }
        else
        {
            // ...
        }
    }
    else
    {
        // ...
    }
    if (doBigCall)
    {
        // write the big bit of code just once
    }
