    class fileHistory
    {
        private readonly List<object> _log = new List<object>();
        public void Add(DateTime ts, int st)
        {
             _log.Add( new { timeStamp = ts; status = st;} );
        }
    }
