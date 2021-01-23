        public class Subscriber : IHandleMessages<Event>
        {
            public void Handle(Event message)
            {
                Console.WriteLine("Handle: "+message.GetType().Name);
            }
    
        }
    
