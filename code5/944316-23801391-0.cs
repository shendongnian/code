    public class CheckThreadSafety
    {
        private static int five = 5;
    
        public static void Increment(i)
        {
            five += i;
        }
        public static int CurrentFiveValue { get { return five; } }
    }
    public class Program
    {
        public static void Main()
        {
            for (var i=1; i=10000; i++)
            {
                Task.Factory.StartNew ( () =>
                {
                    CheckThreadSafety.Increment(i);
                    Console.WriteLine("Five Value should be : " + (i + 5).ToString() + ", and is: " + CheckThreadSafety.CurrentFiveValue);
                }
            }
        }
    }
