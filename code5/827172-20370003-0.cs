    class Class
    {
        // ...
    
        MyFormattedStrings FormattedStrings
        {
            get {return new MyFormattedStringsIndexer<string>(this.dict.Values.ToList());}
        }
    }
    class MyFormattedStringsIndexer<T>
    {
        private IList<T> list;  // we take only reference, so there is no overhead
    
        public MyFormattedStringsCollection (IList<T> list)
        {
            this.list = list;
        }
    
        // the indexer:
        public T this[int i]
        {
            get
            {
                // this is where the lazy stuff happens:
                // compute the desired element end return it
            }
            set
            {
                // ...
            }
        }
    }
