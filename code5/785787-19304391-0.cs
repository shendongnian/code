    namespace SomeNamespace
    {
        using System;
     
        public class MyClass
        {
            public static void HandleFatalEventLog(string level)
            {
                if(level.Equal("Fatal", StringComparison.OrdinalIgnoreCase)) 
                {
                    Environment.Exit(-1);
                }
            }
        }
    }
