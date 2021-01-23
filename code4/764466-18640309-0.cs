    static class DemoUtil
    {
        public static void Print(this object self)
        {
            Console.WriteLine(self);
        }
        public static void Print(this string self)
        {
            Console.WriteLine(self);
        }
    }
