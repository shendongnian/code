    public abstract class BaseClass 
    {
        // Only available to BaseClass
        private string _myString;
        public string DoWork(string str)
        {
            // Available to everyone
            return _myString;
        }
    
        protected void DoWorkInternal() {
            // Only available to classes who inherit base class
        }
    }
