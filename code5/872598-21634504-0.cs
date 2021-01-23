     class Program
        {
            public delegate bool WindowEnumDelegate(IntPtr hwnd,
                                                     int lParam);
    
            [DllImport("user32.dll")]
            public static extern int EnumChildWindows(IntPtr hwnd,
                                                      WindowEnumDelegate del,
                                                      int lParam);
    
            [DllImport("user32.dll")]
            public static extern int GetWindowText(IntPtr hwnd,
                                                   StringBuilder bld, int size);
    
            static void Main(string[] args)
            {
    
                var mainWindowHandle = Process.GetProcessesByName("mpc-hc").First().MainWindowHandle;
                var list = new List<string>();
                EnumChildWindows(mainWindowHandle, (hwnd, param) =>
                                                   {
                                                       var bld = new StringBuilder(256);
                                                       GetWindowText(hwnd, bld, 256);
                                                       var text = bld.ToString();
                                                       if (!string.IsNullOrEmpty(text))
                                                           list.Add(text);
    
                                                       return true;
                                                   }, 0);
    
                Console.WriteLine("length={0}", list[0]);
                Console.WriteLine("state={0}", list[1]);
                Console.WriteLine("bitrate={0}", list[5]);
                Console.WriteLine("name={0}", list[7]);
    
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
