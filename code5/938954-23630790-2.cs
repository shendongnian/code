    public class Calculator
    {
        private static System.Object lockThis = new System.Object();
    
        public static void Add(int a, int b)
        {   
            lock (lockThis)
            {
                return a+b;
            }
        }
    
    }
