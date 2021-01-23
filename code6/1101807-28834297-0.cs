    class Program
    {
        static void Main(string[] args)
        {
            string unconverted = "äüö"; // is what you get when using File.ReadAllText(file)
            byte[] converted = Encoding.Unicode.GetBytes(unconverted);
            converted = converted.Where(x => x != 0).ToArray(); //skip bytes that are 0
            foreach (var item in converted)
            {
                Console.WriteLine(item);
            }
        }
    }
