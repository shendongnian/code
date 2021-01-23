    public class Program
    {
        public static void Main(string[] args)
        {
            SubTest t = new SubTest();
            Console.WriteLine(t.pos.x);
        }
    }
    public class TestSerialize
    {
        [Serializable]
        public struct position
        {
            public int x;
            public int y;
        }
    };
    public class SubTest
    {
        public TestSerialize.position pos;
    }
