    public class CheckThreadSafety
    {
        private static int five = 5;
    
        public static void Increment(int iVal)
        {
            five += iVal;
        }
        public static int CurrentFiveValue { get { return five; } }
    }
    public class Program
    {
        public static void Main()
        {
            for (var i=0; i<10000; i++)
            {   var t = i;
                Task.Factory.StartNew ( () =>
                {   
                    CheckThreadSafety.Increment(t);
                    Console.WriteLine("Five Value should be : " + (t + 5).ToString() + ", and is: " + CheckThreadSafety.CurrentFiveValue);
                } );
            }
        }
    }
