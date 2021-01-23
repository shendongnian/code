    static private void WithCatch(Action f)
    {
        try
        {
            f();
        }
        catch (System.TimeoutException ex)
        {
            Console.WriteLine("System.TimeoutException");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("System.Exception");
        }
    }
    static public void Main(string[] args)
    {
        WithCatch(() => {
            for (int i = 0; i < 10; i++)
               ONE_IndependentProcess(i);
        });
        // You could also do this inside the for loop for each one if you want
        // to attempt all 10 even if one fails:
        //for (int i = 0; i < 10; i++)
        //    WithCatch(() => {ONE_IndependentProcess(i);});
        WithCatch(() => {TWO_IndependentProcess();});
        WithCatch(() => {THR_IndependentProcess();});
    }
