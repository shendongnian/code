    class Test
    {
        int t = 1;
    
        static void Main()
        {
            Base x = new Derived();
            x.Foo(t); // not allowed!
        }
    }
