    class Program
    {        
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void keybd_event(byte vVK, byte bScan, int dwFlags, int dwExtraInfo);
        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //key down
        public const int KEYEVENTF_KEYUP = 0x0002; //key up
        public const int VK_SNAPSHOT = 0x2C; //VirtualKey code for print key
        public static void PrintScreen()
        {
            keybd_event(VK_SNAPSHOT, 0, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event(VK_SNAPSHOT, 0, KEYEVENTF_KEYUP, 0);
        }
        public static void test(Action<Image> action)
        {
            PrintScreen();
            var image = Clipboard.GetImage();
            action.BeginInvoke(image, ar => action.EndInvoke(ar), null);
        }
        [STAThread]
        static void Main(string[] args)
        {
            var processAction = new Action<Image>(img =>
            {
                if (img == null)
                    Console.WriteLine("none");
                else
                    Console.WriteLine(img.PixelFormat);
            });
            test(processAction);
            System.Console.ReadLine();
    }
