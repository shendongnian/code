    using System;
    using System.Diagnostics;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Encoding enc = Encoding.GetEncoding("ISO-8859-1");
                string original = "ESPAÑOL";
                byte[] iso_8859_1 = enc.GetBytes(original);
                string roundTripped = enc.GetString(iso_8859_1);
                Debug.Assert(original == roundTripped);
                Console.WriteLine(roundTripped);
            }
        }
    }
