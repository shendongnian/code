    Class MyObject
    {
        private List<string> _stringList = null;
        
        public List<string> StringList
        {
        
            get
            {
                if(_stringList == null)
                {
                    _stringList = new List<string>();
                    //fill the List with strings from some data source
                }
                return _stringList;
            }
        }
    }
