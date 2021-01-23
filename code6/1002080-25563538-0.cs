    public class MyClass
    {
        private readonly _query = new WriteOnce<string>();
    
        public string Query
        {
            get { return _query.Value; }   
        }
        
        public void SetQuery(string query)
        {
            _query.Value = query;
        }
    }
