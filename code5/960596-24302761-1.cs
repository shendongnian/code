    class Program
    {
       static Class1 s;
       static void Main(string[] args)
       {
           s = new PortableClassLibrary1.Class1(new Impl());
           test().Wait();
    }
    static async Task test()
    {
        bool x = await s.Call().ConfigureAwait(false);
        if(x == true)
        {
            Console.WriteLine("test");
        }
        else
        {
            Console.Write("");
        }
    }
