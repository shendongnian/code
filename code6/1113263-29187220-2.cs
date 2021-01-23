    // Note the name of the class (Nomen est omen)
    public class InsaneClass
    {
        public static implicit operator bool(InsaneClass v)
        {
            Console.WriteLine("Operator bool");
            return true;
        }
        public static bool operator==(InsaneClass v1, bool v2)
        {
            Console.WriteLine("Operator ==");
            return true;
        }
        public static bool operator !=(InsaneClass v1, bool v2)
        {
            Console.WriteLine("Operator !=");
            return true;
        }
    }
