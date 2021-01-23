    private int Method1(int x)
    {
        int y = 0;
        if (x == 0)
        {
            y = 10;
        }
        else if (x == 1)
        {
            y = 20;
        }
        return y;
    }
    private int Method2(int x)
    {
        int y = 0;
        if (x == 0)
        {
            y = 10;
        }
        else
        {
            if (x == 1)
            {
                y = 20;
            }
        }
        return y;
    }
