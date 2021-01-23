    class Program
        {
            static void Main(string[] args)
            {
                var prog = new Program();
                var recipient = new object();
    
                prog.RegisterMessageA(recipient);
                prog.RegisterMessageB(recipient);
    
                prog.SendMessage("First Message");
                GC.Collect();
                prog.SendMessage("Second Message");
            }
    
            public void RegisterMessageA(object target)
            {
                Messenger.Default.Register(target, (Message msg) =>
                {
                    Console.WriteLine(msg.Name + " received by A");
                    var x = msg.Target;
                });
            }
    
            public void RegisterMessageB(object target)
            {
                Messenger.Default.Register(target, (Message msg) =>
                {
                    Console.WriteLine(msg.Name + " received by B");
                });
            }
    
            public void SendMessage(string name)
            {
                Messenger.Default.Send(new Message { Name = name });
            }
    
            class Message : MessageBase //part of the MVVM Light framework
            {
                public string Name { get; set; }
            }
        }
