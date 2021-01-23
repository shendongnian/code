    public void Foo(object o)
    {
        if (o is B)
        {
            Foo((B)o);
        }
        else
        {
            Console.WriteLine("general");
        }
    }
