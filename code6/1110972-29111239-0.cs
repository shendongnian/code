    public class Foo
    
        private string _bar;
        public string Bar
        {
            set
            {
                this._bar = value;
            }    
            get
            {
                return _bar;
            }
        }
    
        public Foo(string bar)
        {
            this.Bar = bar;
        }
    }
