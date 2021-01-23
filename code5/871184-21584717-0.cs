    public class TheDataContext
    {
        public TheDataContext()
        {
            _listOfAs = new List<A>
            {
                new A(),
                new A(),
                new A() 
            };
            _listOfBs = new ObservableCollection<B>(_listOfAs.SelectMany(a => a.B));
        }
        private List<A> _listOfAs;
        private ObservableCollection<B> _listOfBs;
        public ObservableCollection<B> ListOfBs
        {
            get
            {
                return _listOfBs;
            }
        }
    }
    public class A
    {
        public A()
        {
            B = new List<B>
            {
                new B(),
                new B(),
                new B()
            };
        }
        public IEnumerable<B> B { get; set; }
    }
    public class B
    {
        
    }
