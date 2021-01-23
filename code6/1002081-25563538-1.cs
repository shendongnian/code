    public class MyClass
    {
        private readonly _query = new WriteOnce<string>();
    
        public string Query
        {
            private get { return _query.Value; }
            set { _query.Value = value; }
        }        
    }
