    internal static class Program
    {
        private static void Main()
        {
            var bytes1 = new byte[] {0x00, 0x61, 0x25, 0x54};
            var bytes2 = new byte[] {0xFE, 0xFF, 0x00, 0x61, 0x25, 0x54};
            
            Write(bytes1); // Write: ' a%T'
            Write(bytes2); // Write: 'a╔'
            Console.ReadKey();
        }
        private static void Write(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                using (var sr = new StreamReader(ms))
                {
                    var str = sr.ReadToEnd();
                    Console.WriteLine(str);
                }
            }
        }
    }
