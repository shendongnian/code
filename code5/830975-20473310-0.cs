    public class Guess
    {
        ...
        public override bool Equals(object obj)
        {
            // determine equality
        }
        public override int GetHashCode()
        {
            // if you have an INT primary key here, it would be good to use that
            // Example: return this.IntProperty.GetHashCode();
        }
    }
