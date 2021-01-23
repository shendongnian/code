    using System.Runtime.InteropServices;
    namespace ConsoleApplication1
    {
        class Program
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct POINT
            {
                public int X;
                public int Y;
            }
            [DllImport("user32.dll")]
            public static extern bool GetCursorPos(out POINT lpPoint);
            public static POINT GetCursorPosition()
            {
                POINT lpPoint;
                GetCursorPos(out lpPoint);
                return lpPoint;
            }
    
            static void Main(string[] args)
            {
                var timer = new System.Threading.Timer(
                    e =>
                    {
                        var p = GetCursorPosition();
                        Console.WriteLine(string.Format("X: {0}, Y: {1}", p.X, p.Y));
                    },
                    null,
                    TimeSpan.Zero,
                    TimeSpan.FromSeconds(5));
    
                Console.ReadLine();
            }
        }
    }
