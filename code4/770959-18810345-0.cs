    using System;
    using System.Runtime.InteropServices;
    namespace Test
    {   
        public class Program
        {
            [DllImport("kernel32")]
            private static extern int SetConsoleMode(IntPtr hConsole, int dwMode);
            // http://msdn.microsoft.com/en-us/library/windows/desktop/ms683167(v=vs.85).aspx
            [DllImport("kernel32")]
            private static extern int GetConsoleMode(IntPtr hConsole, out int dwMode);
            // see http://msdn.microsoft.com/en-us/library/windows/desktop/ms683231(v=vs.85).aspx
            [DllImport("kernel32")]
            private static extern IntPtr GetStdHandle(int nStdHandle);
            // see docs for GetStdHandle. Use -10 for STDIN
            private static readonly IntPtr hStdIn = GetStdHandle(-10);
            // see docs for GetConsoleMode
            private const int ENABLE_ECHO_INPUT = 4;
	
            public static void Main(string[] args)
            {
                 Console.WriteLine("Changing console mode");
                 int mode;
                 GetConsoleMode(hStdIn, out mode);
                 SetConsoleMode(hStdIn, (mode & ~ENABLE_ECHO_INPUT));
                 Console.WriteLine("Mode set");
                 Console.Write("Enter input: ");
                 string value = Console.ReadLine();
                 Console.WriteLine();
                 Console.WriteLine("You entered: {0}", value);
            }
        }
    }
