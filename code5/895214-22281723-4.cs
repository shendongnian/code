    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace ConsoleApplication
    {
        class Program
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
    
            private const int MOUSEEVENTF_LEFTDOWN = 0x02;
            private const int MOUSEEVENTF_LEFTUP = 0x04;
            //private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
            //private const int MOUSEEVENTF_RIGHTUP = 0x10;
    
            public void DoMouseStuff()
            {
                Cursor.Current = new Cursor(Cursor.Current.Handle);
                var point = new Point(Cursor.Position.X, Cursor.Position.Y);
                for (int i = 0; i < 20; i++, point.X += 10, point.Y += 10)
                {
                    Cursor.Position = point;
                    Program.mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
                    System.Threading.Thread.Sleep(100);
                }
            }
    
            static void Main(string[] args)
            {
                var prog = new Program();
                prog.DoMouseStuff();
            }
        }
    }
