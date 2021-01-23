    class MyClass{
        public string Data { get; set; }
        private IList<string> _list;
        public IList<string> List1
        {
            get
            {
                return _list ?? (_list = new List());
            }
        }
        private readonly Lazy<IList<string>> _lazyList = new Lazy<IList<string>>(() => new List<string>()); 
        public IList<string> List2 {get { return _lazyList.Value; }} 
    
    }
