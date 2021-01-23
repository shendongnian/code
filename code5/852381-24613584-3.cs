    class MyClass{
        public string Data { get; set; }
        private IList<string> _list0 = new List();
        public IList<string> List0
        {
            get
            {
                return _list0;
            }
        }
        private IList<string> _list1;
        public IList<string> List1
        {
            get
            {
                return _list1 ?? (_list1 = new List());
            }
        }
        private readonly Lazy<IList<string>> _lazyList = new Lazy<IList<string>>(() => new List<string>()); 
        public IList<string> List2
        {
            get
            {
                 return _lazyList.Value;
            }
        } 
    
    }
