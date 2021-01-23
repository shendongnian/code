    using System;
    using System.Drawing.Text;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Drawing;
    namespace FORM
    {
        class MainClass
        {
            public static void Main (string[] args)
            {
                using (PrivateFontCollection pf = new PrivateFontCollection())
                {
                    IntPtr fontBuffer = IntPtr.Zero;
                    pf.AddFontFile("C:\\Windows\\Fonts\\times.ttf");
                    Font f = new Font(pf.Families[0], 12, FontStyle.Regular);
                }
                Console.WriteLine("Hello World!");
                Console.ReadLine();
            }
        }
    }
