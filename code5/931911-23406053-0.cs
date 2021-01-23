    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace ConsoleApplication69
    {
        class Program
        {
            static void Main(string[] args)
            {
                KeyboardSend.KeyDown(Keys.LWin);
                KeyboardSend.KeyUp(Keys.LWin);
            }
        }
    
        static class KeyboardSend
        {
            [DllImport("user32.dll")]
            private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
    
            private const int KEYEVENTF_EXTENDEDKEY = 1;
            private const int KEYEVENTF_KEYUP = 2;
    
            public static void KeyDown(Keys vKey)
            {
                keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
            }
    
            public static void KeyUp(Keys vKey)
            {
                keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
       
     }
    }
