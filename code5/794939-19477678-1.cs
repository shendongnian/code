    static void Main()
    {
       int val = 10;
       Program p = new Program();
       p.fnctest(val);
       Console.WriteLine(val);
    }
    void fnctest(int val)
    {
       val = 200;
    }
