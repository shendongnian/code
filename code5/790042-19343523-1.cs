    namespace ConsoleApplication1
    {
        using System;
        using System.Text;
    
        class Program
        {
            static void Main(string[] args)
            {
                string profilepic = "/9j/4AAQ";
                string New = Convert.ToBase64String(Encoding.Unicode.GetBytes(profilepic));
                byte[] raw = Convert.FromBase64String(New); // unpack the base-64 to a blob
                string s = Encoding.Unicode.GetString(raw); // outputs /9j/4AAQ
                Console.ReadKey();
            }
        }
    }
