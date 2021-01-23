    using System;
    using System.Runtime.CompilerServices;
    
    class Test
    {
        static void Main()        
        {
            Console.WriteLine(IsThisAsync(() => {}));       // False
            Console.WriteLine(IsThisAsync(async () => {})); // True
        }
        
        static bool IsThisAsync(Action action)
        {
            return action.Method.IsDefined(typeof(AsyncStateMachineAttribute),
                                           false);
        }
    }
