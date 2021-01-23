    public void Method(int param1 = 0, int param2 = 0, int param3) //Param3 isn't optional.
    {
        //This does not!
    }
    public void Method(int param1 = 0, int param2, int param3 = 0) //Param2 isn't optional.
    {
        //Neither does this!
    }
