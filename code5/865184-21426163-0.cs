    using System;
    namespace Demo
    {
        public class SomeClass
        {
            public string name;
            private int minValue;
            private int maxValue;
            public int currValue;
            public int getCurrentValue()
            {
                return currValue;
            }
            public static implicit operator int(SomeClass value)
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                return value.currValue;
            }
        }
        internal class Program
        {
            private void run()
            {
                var test = new SomeClass {currValue = 5};
                if (test - 5 == 0)
                    Console.WriteLine("It worked");
                if (test + 5 == 10)
                    Console.WriteLine("This also worked");
            }
            private static void Main()
            {
                new Program().run();
            }
        }
    }
