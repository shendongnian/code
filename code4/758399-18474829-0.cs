    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace directorysearch
    {
        class Program
        {
            static void Main(string[] args)
            {
                DirectoryInfo di = new DirectoryInfo(@"c:\users\documents\development\testing");
                FileInfo[] files = null;
                DirectoryInfo[] dirs = null;
                dirs = di.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    files = dir.GetFiles("*", SearchOption.TopDirectoryOnly);
                }
            }
        }
    }
