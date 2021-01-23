    public override int DivTwoNumbers(int a, int b)
    {
        return a / b;
    }
    static void Main(string[] args)
    {
        AbsClass prog = new Program();
        try
        {
            int div = prog.DivTwoNumbers(10, 0);
            Console.WriteLine("Division Of Number Is : {0} ", div);
        }
        catch(Exception ex)
        {
            Console.WriteLine("ErrorMessage :" +ex);
        }
        
    }
