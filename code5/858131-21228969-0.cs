    public class B
    {
        public event Action<int> SomethingHappened; // define event
    
        private void Something()
        {
            if (SomethingHappened != null) // check if somebody subscribed
                SomethingHappened(42); // raise event and pass data
        }
    }
