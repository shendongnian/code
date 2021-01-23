    void Code()
    {
        try
        {
            Console.WriteLine("a");
            throw new Exception(); //the code will stop executing here
            Console.WriteLine("b");
        }
        catch(Exception e)
        {
            Console.WriteLine("b");
            throw new Exception(e.toString());
        }
    }
