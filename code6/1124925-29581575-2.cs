    // Check that I dropped the lazy approach of using 
    // anonymous types!!
    class fileHistory : IEnumerable<FileLog>
    {
        private readonly List<FileLog> _log = new List<FileLog>();
        public IEnumerator<FileLog> GetEnumerator() 
        {
             return _log.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _log.GetEnumerator();
        }
    
        public void Add(DateTime ts, int st)
        {
             _log.Add(new FileLog { timeStamp = ts; status = st;} );
        }
    }
