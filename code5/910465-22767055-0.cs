    public class EventLogger
    {   
        public void Subscribe<T>(T obj)
        {
            // get the type to iterate over the EventInfo's
            var type = typeof (T);
            foreach (var eve in type.GetEvents())
            {
                EventInfo info = eve;
                // attach our logging logic 
                eve.AddEventHandler(obj, 
                    new EventHandler((sender, args) =>
                        {
                            Console.WriteLine(
                                "{0} {1}.{2}", 
                                DateTime.Now, 
                                obj,
                                info.Name);
                        }));
            }
        }
    
        public void Unsubscribe()
        {
            //todo unsubscribe
        }
    
    }
