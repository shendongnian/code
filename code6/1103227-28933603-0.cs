    using System;
    
    public class MyServer : MarshalByRefObject
    {
        Guid clientID;
    
        public MyServer(Guid clientID)
        {
            this.clientID = clientID;
        }
    
        public void DoSomething()
        {
            Console.WriteLine("Logged operation from client {0}.", this.clientID);
        }
    }
