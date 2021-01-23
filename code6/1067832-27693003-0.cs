    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Drawing;
    using System.Net;
    namespace GDI
    {
        class Program
        {
            static void Main(string[] args)
            {
                WebClient wc = new WebClient();
                Bitmap bmp = new Bitmap(wc.OpenRead("https://s0.2mdn.net/viewad/3092927/Freedom_AW_D_Zenith_119053_DS_Apple_Pay_Bleachers_300x250.jpg"));
                Console.WriteLine("Width=" + bmp.Width.ToString() + ", Height=" + bmp.Height.ToString());
                Console.ReadLine();
            }
        }
    }
