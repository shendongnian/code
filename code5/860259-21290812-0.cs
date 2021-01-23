    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    
    public class Test
    {
        static void Log(string message,
                        [CallerFilePath] string file = null,
                        [CallerLineNumber] int line = 0)
        {
            Console.WriteLine("{0} ({1}): {2}", Path.GetFileName(file), line, message);
        }
        
        static void Main()
        {
            Log("Hello, world");
            Log("This is the next line");
        }
    }
