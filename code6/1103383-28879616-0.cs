    public void Main ()
    {
        try
        {
            try
            {
                throw new Exception("Original exception");
            }
            catch (Exception ex)
                if (Test())
            {
                Console.WriteLine("Caught the exception");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    public static bool Test ()
    {
        throw new Exception("Exception in filter condition");
    }
