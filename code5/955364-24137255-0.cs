    class Program
    {
        static void Main(string[] args)
        {
            var writeText = "你叫什么名字？";
            var writeBytes = System.Text.UTF8Encoding.Unicode.GetBytes(writeText);
            File.WriteAllBytes("D:\\test.txt", writeBytes);
    
            var readBytes = File.ReadAllBytes("D:\\test.txt");
            var readText = System.Text.UTF8Encoding.Unicode.GetString(readBytes);
            Console.WriteLine(readText);
        }
    }
