    public class Example {
        public virtual int Number { get; set; }
        public Example(int numberArg) {
            this.Number = numberArg;
        }
    }
    public class AnotherExample : Example {
        public overrides int Number 
        {
            get{return 5;}
            set{}
        }
        public int DoubleNumber {
            get {
                return this.Number * 2; // returns 10
                return base.Number * 2 // returns 2 times whatever the value is 
            }
        }
        public AnotherExample(int numberArg) : base(numberArg) {}
    }
