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
            return (MyDel)Attack + SwingSword;
        }
        return Idle;
    }
