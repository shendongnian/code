    using System;
    
    class Program
    {
        static void Main()
        {
            Action action1 = GetAction();
            Action action2 = GetAction();
            Console.WriteLine(ReferenceEquals(action1, action2)); // True
        }
    
        private static Action GetAction()
        {
            return () => {};
        }
    }
