    class Property
    {
        private string _name = "_name";
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public void Foo()
        {
            _name = "foo";
        }
        static void Main(string[] args)
        {
            Property prop = new Property();
            Console.WriteLine(prop.Name);  // prints _name
        
            prop.Foo();
            Console.WriteLine(prop.Name); // prints foo
        }
    }
