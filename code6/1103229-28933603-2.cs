    using System;
    using System.Runtime.Remoting;
    
    class Client
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.RegisterActivatedClientType(typeof(MyServer),
                                          "tcp://localhost:1234/Test");
            var id = Guid.NewGuid();
            Console.WriteLine("Creating object with id {0}.", id);
            var obj = new MyServer(id);
            obj.DoSomething();
        }
    }
