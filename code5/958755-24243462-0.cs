    using System;
    using System.IO;
    using System.Text;
    
    class Test
    {
        static void Main()
        {
            string text = "text";
            var encoding = Encoding.UTF8;
            Console.WriteLine(encoding.GetByteCount(text));
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream, encoding))
                {
                    writer.Write(text);
                }
                Console.WriteLine(BitConverter.ToString(stream.ToArray()));
            }
        }
    }
