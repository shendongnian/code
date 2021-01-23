    private readonly IEnumerable<xyz> _xyz;
        public IEnumerable<xyz> XYZ
        {
            get
            {
                foreach(var item in _xyz)
                {
                    yield return item; // Every time will get returned 1 by 1 as the caller énumérâtes this, no list is ever returned
                }
            }
        }
