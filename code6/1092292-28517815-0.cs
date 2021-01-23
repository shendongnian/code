    public class petri {
        private readonly object _lock = new object();
    
        public bool start() {
            lock(_lock)
            {
                // rest of method here
            }
        }
    
        public bool end() {
            lock(_lock)
            {
                // rest of method here
            }
        }
    }
