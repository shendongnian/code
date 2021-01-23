    class MyList<T>
        where T : class, IConvertible
    {
        private List<T> list = new List<T>();
        
        public void Add(string s)
        {
            list.Add(s); // error
        }        
    }
