    using System.IO;
    using System;
    using System.Text;
    
    class Program
    {
        static void Main()
        {
            string input = "test input";
            byte[] key = new byte[input.Length];
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < key.Length; i++)
            {
                key[i] = (byte)r.Next();
            }
            var result = Encrypt(input, key);
            Console.WriteLine(result);
        }
        
        static string Encrypt(string inp, byte[] key){
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < inp.Length; i++)
            {
                sb.Append(inp[i] & key[i]);
            }
            return sb.ToString();
        }
    }
