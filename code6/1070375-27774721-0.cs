    public class Hoge
    {
        // A dictionary to store your events.
        private Dictionary<string, EventHandler> events = new Dictionary<string, EventHandler>()
        {
            { "EventA", null },
            { "EventB", null },
            { "EventC", null }
        };
    
        // Event add/remove accessors.
        public event EventHandler EventA
        {
            add
            {
                lock (events)
                {
                    events["EventA"] += (EventHandler)events["EventA"] + value;
                }
            }
            remove
            {
                lock (events)
                {
                    events["EventA"] += (EventHandler)events["EventA"] - value;
                }
            }
        }
    
        // You can do the same for other events.
        public event EventHandler EventB;
        public event EventHandler EventC;
    
        public Hoge()
        {
            // Initialize events in a loop.
            foreach (var key in events.Keys.ToList())
            {
                events[key] += FugaMethod;
            }
        }
    
        // Raises EventA.
        public void RaiseEventA()
        {
            EventHandler handler;
            if (null != (handler = (EventHandler)events["EventA"]))
            {
                handler(this, EventArgs.Empty);
            }
        }
    
        // Event handler.
        private void FugaMethod(object sender, EventArgs e)
        {
            Console.WriteLine("Hello.");
        }
    }
