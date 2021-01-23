    static public void Main(string[] args)
    {
        try
        {
            for (int i = 0; i < 10; i++)
            {
                ONE_IndependentProcess(i);
            }
        }
        catch (System.TimeoutException ex)
        {
            Console.WriteLine("System.TimeoutException");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("System.Exception");
        }
        finally
        {
            Console.WriteLine("End.");
        }
        try
        {
            TWO_IndependentProcess();
        }
        catch (System.TimeoutException ex)
        {
            Console.WriteLine("System.TimeoutException");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("System.Exception");
        }
        finally
        {
            Console.WriteLine("End.");
        }
        try
        {
            THR_IndependentProcess();
        }
        catch (System.TimeoutException ex)
        {
            Console.WriteLine("System.TimeoutException");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("System.Exception");
        }
        finally
        {
            Console.WriteLine("End.");
        }
    }
