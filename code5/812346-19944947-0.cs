    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ExtractLine("fileName.txt", 4));
            Console.ReadKey();
        }
        static string ExtractLine(string fileName, int line)
        {
            string[] lines = File.ReadAllLines(fileName);
            return lines[line - 1];
        }
    }
