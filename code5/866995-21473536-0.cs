    public class ParameterClass
    {   
        private lockObject = new object();
        private string a = string.Empty;
        private Int64 b = 0;
        public SafeSet(string v, long number)
        {
            lock(lockObject) 
            {
                 a = v;
                 b = number;
            }
        }
        public string A
        {
            get { lock(lockObject)  { return a; } }
        }
        public long B
        {
            get { lock(lockObject)  { return b; } }
        }
    }
