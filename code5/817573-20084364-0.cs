    public void Foo(object o){
            B test = o as B;
        if(test == null){
            Console.WriteLine("general");
        }else
    {
    Console.WriteLine("specific");
    }
    }
