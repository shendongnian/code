    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    namespace throw_test
    {
        static class Program
        {
            static void Main()
            {
                List<string> myStrings = new List<string>();
                myStrings.Add("abc");
                myStrings.Add("def");
                Console.WriteLine(myStrings[0]); // outputs: "abc"
                Console.WriteLine(myStrings[1]); // outputs: "def"
                Console.Read();
            }
        }
    }
