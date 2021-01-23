    for(;;)
    {
        if (condition1)
        {
            Log("condition1");
        }
        else
        {
            if (condition2)
            {
                Log("condition2");
            }
            else
            {
                if (condition3)
                {
                    Log("condition3");
                }
                else
                {
                    DoSomething();
                }
            }
        }
    }
