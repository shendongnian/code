    // Program.cs
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    
    namespace FixedLengthFileReader
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyData md = new MyData();
                Console.WriteLine(md);
    
                Stream s = File.OpenRead("testFile.bin");
                FixedLengthReader flr = new FixedLengthReader(s);
                flr.read(md);
                s.Close();
    
                Console.WriteLine(md);
            }
        }
    }
