    public void Anon()
    {
         var x = new {foo = "bar"};
         AnonReciever(x);
    }
    public static void AnonReciever(dynamic o)
    {
         Console.WriteLine(o.foo);
    }
