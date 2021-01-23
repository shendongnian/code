    interface IDoStuffWithExtensions : IDoStuff
    {
        string SayHelloToBob();
    }
    
    class MyClass : IDoStuffWithExtensions
    {
        public string SayHello()
        {
            return "Hello";
        }
    
        // Wrap / internalise the extension method
        public string SayHelloToBob()
        {
            return DoStuffExtensions.SayHelloToBob(this);
        }
    }
    
    class UserOfIDoStuff
    {
        void UseIDoStuff(IDoStuffWithExtensions incoming)
        {
            Console.WriteLine(incoming.SayHelloToBob());
        }
    }
