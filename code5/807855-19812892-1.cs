    static MyDel AI(int c) 
    {
        if(c == 'a')
        {
            return Attack;
        }
        if(c == 'i')
        {
            return Idle;
        }
        if (c == 's')
        {
            return SwingSword;
        }
        if (c == 'w')
        {
            return Attack+ SwingSword;
        }
        return Idle;
    }
