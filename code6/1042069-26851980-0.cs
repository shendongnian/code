    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            string originalText = "Hello world! ブ䥺ぎょズィ穃 槞こ廤樊稧 ひゃご禺 壪";
            byte[] rgb = Encoding.UTF8.GetBytes(originalText);
            MemoryStream dataStream = new MemoryStream(rgb);
            string result = DecodeOneByteAtATimeFromStream(dataStream);
            Console.WriteLine("Result string: \"" + result + "\"");
            if (originalText == result)
            {
                Console.WriteLine("Original and result strings are equal");
            }
        }
        static string DecodeOneByteAtATimeFromStream(MemoryStream dataStream)
        {
            Decoder decoder = Encoding.UTF8.GetDecoder();
            StringBuilder sb = new StringBuilder();
            int inputByteCount;
            byte[] inputBuffer = new byte[1];
            while ((inputByteCount = dataStream.Read(inputBuffer, 0, 1)) > 0)
            {
                int charCount = decoder.GetCharCount(inputBuffer, 0, 1);
                char[] rgch = new char[charCount];
                decoder.GetChars(inputBuffer, 0, 1, rgch, 0);
                sb.Append(rgch);
            }
            return sb.ToString();
        }
    }
