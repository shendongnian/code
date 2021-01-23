    public class MyClass
    {
        private List<string> _list = new List<string>();
    
        public MyClass()
        {
            _list.Add("banana");
            _list.Add("orange");
            _list.Add("apple");
        }
    
        public IReadOnlyCollection<string> ReadOnly
        {
            get { return _list; }
        }
    
        public IReadOnlyCollection<string> ReadOnlyWithWrapper
        {
            get { return _list.AsReadOnly(); }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass my = new MyClass();
    
            //modify by hack
            ((List<string>)my.ReadOnly).Add("Cherries");
    
            Console.WriteLine("no wrapper");
    
            foreach (var item in my.ReadOnly)
            {
                Console.WriteLine(item); //will include cherries
            }
    
            Console.WriteLine("with wrapper");
            MyClass my2 = new MyClass();
    
            //cannot be modify by hack, unless reflection is used
            //throw InvalidCastException
            ((List<string>)my2.ReadOnlyWithWrapper).Add("cherries");    
        }
    }
