    using System;
    class P
    {
        static void Main()
        {
            new P().Test();
        }
        public Result Result { get; set; }
        public void Test()
        {
            var x = (this.Result == Result.OK);
            Console.WriteLine(x.GetType().Name); // Int32
        }
    }
    public class Result
    {
        public static Result OK { get { return null; } }
        public static int operator ==(Result x, Result y)
        {
            return 42; // DO NOT EVER DO THIS
        }
        public static int operator !=(Result x, Result y)
        {
            return 0; // DO NOT EVER DO THIS
        }
    }
