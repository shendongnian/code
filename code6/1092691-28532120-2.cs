     class Tester
        {
            public void Go()
            {
                var a = new MessageA();
                var b = new MessageB();
                var c = new MessageC();
    
                var router = new MessageRouter();
                router.RegisterHandler(new HandlerA());
                router.RegisterHandler(new HandlerB());
    
                router.Route(a);
                router.Route(b);
                router.Route(c);
            }
        }
    
        class MessageRouter
        {
           Dictionary<Type, dynamic> m_handlers = new Dictionary<Type,dynamic>();
            public void RegisterHandler<T>(IMessageHandler<T> handler)
            {
                m_handlers.Add(typeof(T), handler);
            }
    
            public void Route(dynamic message)
            {
                var messageType = message.GetType();
                if (m_handlers.ContainsKey(messageType))
                {
                    m_handlers[messageType].Handle(message);
                }
                else
                {
                    foreach (var pair in m_handlers)
                    {
                        if(pair.Key.IsAssignableFrom(messageType))
                        {
                            pair.Value.Handle(message);
                        }
                    }
                }
            }
    
        }
    
        class MessageA
        {
            public virtual string A { get { return "A"; } }
        }
        class MessageB
        {
            public  string B { get { return "B"; } }
        }
    
        class MessageC :MessageA
        {
            public  override string A {  get { return "C"; } }
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
