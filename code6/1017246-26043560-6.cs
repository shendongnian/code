    abstract class Number
    {
        public static implicit operator int(Number number)
        {
            return number.Value;
        }
        public static implicit operator Number(int val) { Value = value; }
        public abstract  int Value { get; set; }
    }
    internal class Mass : Number
    {
        public override int Value { get; set; }
        public static implicit operator Mass(int val) { return new Mass(){ Value = val }; }
    }
    internal class Volume : Number
    {
        public static implicit operator Volume(int val) { return new Volume(){ Value = val }; }
        public override int Value { get; set; }
    }
    
    var mass = new Mass { Value = 10 };
    var volume = new Volume { Value = 20 };
    int product = mass * volume; // should work
    mass = 10 * 20; // should also work
