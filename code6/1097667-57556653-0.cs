    using System;
    
    interface IDoStuff
    {
        string SayHello();
    }
    
    class MyClass : IDoStuff
    {
        public string SayHello()
        {
            return "Hello";
        }
    }
    
    // somewhere someone wrote an extension method for IDoStuff
    
    static class DoStuffExtensions
    {
        static string SayHelloToBob(this IDoStuff other)
        {
            return other.SayHello() + " Bob";
        }
    }
    
    class UserOfIDoStuff
    {
        void UseIDoStuff(IDoStuff incoming)
        {
            Console.WriteLine(incoming.SayHelloToBob());
        }
    }
