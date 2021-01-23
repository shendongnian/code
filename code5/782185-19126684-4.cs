    void Main()
    {
        Console.WriteLine(AddEm(parm3:50)); // = 80
        Console.WriteLine(AddEm(parm2:50)); // = 90
        Console.WriteLine(AddEm());         // = 60)
    }
    
    public int AddEm(int parm1 = 10, int parm2 = 20, int parm3 = 30) {
        return parm1 + parm2 + parm3;
    }
