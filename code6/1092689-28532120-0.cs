      class Tester
        {
            public void Go()
            {
                var a = new MessageA();
                var b = new MessageB();
    
                var router = new MessageRouter();
    
                router.Route(a);
                router.Route(b);
    
            }
        }
    
        class MessageRouter
        {
            public void Route(dynamic a)
            {
                this.Handle(a);
               
            }
            public void Handle(MessageA a)
            {
                (new HandlerA()).Handle(a);
            }
    
            public void Handle(MessageB b)
            {
                (new HandlerB()).Handle(b);
            }
    
        }
    
        class MessageA
        {
            public string A { get { return "A"; } }
        }
        class MessageB
        {
            public string B { get { return "B"; } }
        }
        interface IMessageHandler<T>
        {
            void Handle(T message);
        }
        class HandlerA : IMessageHandler<MessageA>
        {
    
            public void Handle(MessageA message)
            {
                Console.WriteLine(message.A);
            }
        }
    
        class HandlerB : IMessageHandler<MessageB>
        {
    
            public void Handle(MessageB message)
            {
                Console.WriteLine(message.B);
            }
        }
