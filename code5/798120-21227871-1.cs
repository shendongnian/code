        class Program
    {
        static void Main(string[] args)
        {
            SomeVersion someVersion = new SomeVersion(3, 8);
            if (someVersion.Version == 3.8f)
            {
                Console.WriteLine("Version is 3.8");
            }
            Console.ReadLine();
        }
    }
    public class SomeVersion
    {
        private int _major;
        private int _minor;
        public SomeVersion(int major, int minor)
        {
            _major = major;
            _minor = minor;
        }
        public float Version
        {
            get
            {
                return (float)_major + (_minor * 0.1f);
            }
        }
    }
