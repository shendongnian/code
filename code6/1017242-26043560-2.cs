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
    
    int mass = new Mass { Value = 10 };
    int volume = new Volume { Value = 20 };
    int product = mass * volume; // should work
