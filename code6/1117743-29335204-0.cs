    abstract class Base {
        public abstract string Name { get; }
    }
   
    class Derived1 : Base {
        public override string Name { get { return "Foobar"; } }
    }
    class Derived2 : Base {
        private string _name;
		public override string Name { get { return _name; } }
		public Derived2(string name) { _name = name; }
    }
