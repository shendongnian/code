    public class MyClass
    {
        public int Sender { get; set; }
        public int Receiver { get; set; }
        
        public override int GetHashCode()
        {
            return Sender ^ Receiver;
        }
        public override bool Equals(object other)
        {
            if (other == null || this.GetType() != other.GetType())
                return false;
            var o = (MyClass)other;
            return Math.Min(this.Sender, this.Receiver) == Math.Min(o.Sender, o.Receiver) &&
                Math.Max(this.Sender, this.Receiver) == Math.Max(o.Sender, o.Receiver);
        }
    }
    // use like
    var myList = new List<MyClass>
    {
        new MyClass { Sender = 1, Receiver = 2 },
        new MyClass { Sender = 2, Receiver = 1 },
        new MyClass { Sender = 1, Receiver = 3 },
        new MyClass { Sender = 1, Receiver = 2 },
        new MyClass { Sender = 3, Receiver = 1 },
        new MyClass { Sender = 2, Receiver = 1 },
    };
    var distinctOnes = myList.Distinct(); // contains 1,2 and 1,3
