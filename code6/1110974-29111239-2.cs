    public class Foo
    
        private string _bar;
        public string Bar
        {
            set
            {
                this._bar = value + " blah blah";
            }    
            get
            {
                return _bar;
            }
        }
    
        public Foo()
        {
            this.Bar = "test";
            Console.WriteLine(Bar); // outputs "test blah blah"
            this._bar = "test";
            Console.WriteLine(Bar); // outputs "test"
        }
    }
