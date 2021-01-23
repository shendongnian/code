    using System;
    using System.Text;
    
    class Program
    {
        static void Main(string[] args)
        {
            byte[] hash1 = FillBytes(128);
            byte[] hash2 = FillBytes(129);
            string text1 = Encoding.UTF8.GetString(hash1);
            string text2 = Encoding.UTF8.GetString(hash2);
            Console.WriteLine(text1 == text2);
        }
        
        static byte[] FillBytes(byte data)
        {
            byte[] bytes = new byte[16];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = data;
            }
            return bytes;
        }
    }
