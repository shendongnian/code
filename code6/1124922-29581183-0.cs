    class fileHistory<Object> : List<Object>
    {
        public new void Add(DateTime ts, int st)
        {
            // That's how it's supposed to be
            base.Add(new { timeStamp = ts, status = st });
        }
    }
