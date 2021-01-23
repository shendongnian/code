    class Program
    {
        static void Main()
        {
            Console.Write("Hello".Append("Mark"));
        }
    }
    public static class Ext
    {
        public static System.String Append(this System.String str, System.String app)
        {
            return System.String.Format("{0} {1}", str,app);
        }
    }
