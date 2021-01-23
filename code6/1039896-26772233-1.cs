    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    
    namespace proces
    {
        class Program
        {
            static void Main(string[] args)
            {
                create_process__A("Balotelli");
                create_process__B("Pirlo");
            }
    
             static void create_process__A(string t)
            {
                Process.Start("http://google.com/search?q=" + t);
                
            }
             static void create_process__B(string t)
             {
                 Process.Start("http://google.com/search?q=" + t);
    
             }
        }
    }
