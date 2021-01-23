    static void Main(string[] args)
    {
        Program pr = new Program();
        Action tempName1 = pr.action;
        Action tempName2 = tempName1;
        //pr.action();
        tempName2();
    }
