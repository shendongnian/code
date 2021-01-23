    class Program
    {
        static void Main(string[] args)
        {
            var commandContent = "C:\\Users\\Me\\file.exe\n";
            var commandContentBytes = System.Text.Encoding.UTF8.GetBytes(commandContent);
            var invalidPathChars = System.IO.Path.GetInvalidPathChars().Select(x=>Convert.ToByte(x));
            var found = commandContentBytes.Intersect(invalidPathChars);
        }
    }
