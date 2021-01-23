    abstract class Number
    {
        public static implicit operator int(Number number)
        {
            return number.Value;
        }
        public abstract  int Value { get; set; }
    }
    internal class Mass : Number
    {
        public override int Value { get; set; }
    }
    internal class Volume : Number
    {
        public override int Value { get; set; }
    }
    
    var mass = new Mass { Value = 10 };
    var volume = new Volume { Value = 20 };
    int product = mass * volume; // should work
