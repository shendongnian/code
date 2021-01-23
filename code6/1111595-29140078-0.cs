    public class SomeClass : ISupportInitialize
    {
        private bool initializing;
        private DateTime start;
        private DateTime end;
    
        public DateTime Start
        {
            get { return start; }
            set { CheckInitializing(); start = value; }
        }
    
        public DateTime End
        {
            get { return end; }
            set { CheckInitializing(); end = value; }
        }
    
        private void CheckInitializing()
        {
            if (!initializing)
            { throw new InvalidOperationException("Can not execute this operation outside a BeginInit/EndInit block."); }
        }
    
        public void BeginInit()
        {
            if (initializing)
            { throw new InvalidOperationException("Can not have nested BeginInit calls on the same instance."); }
    
            initializing = true;
        }
        public void EndInit()
        {
            if (!initializing)
            { throw new InvalidOperationException("Can not call EndInit without a matching BeginInit call."); }
    
            if (start <= end)
            { throw new InvalidDates(); }
    
            initializing = false;
        }
    }
