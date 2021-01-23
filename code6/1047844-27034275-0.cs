    public void Swap(ref int a, ref int b) 
    {
        int c = b;
        b = a;
        a = c;
    }
    
    public void DoSwap()
    {
       int x = 1;
       int y = 2;
       Console.WriteLine(x + " "  + y); // should write 1 2
       Swap(ref x, ref y);
       Console.WriteLine(x + " "  + y); // should write 2 1
    }
