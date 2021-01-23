    class Program
    {
        static string[] array;
        static void Main(string[] args)
        {
            var lines = ReadFile("dummy.txt");
            foreach (string line in lines)
            {
                array = CreateArray(line);
                Display();
            }
            
            Console.ReadLine();
        }
        static string[] ReadFile(string fileName)
        {
            var lines = new List<string>();
            using (var file = new StreamReader(fileName))
            {
                string line = string.Empty;
                while ((line = file.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines.ToArray();
        }
        static string[] CreateArray(string line)
        {
            return line.Split(',');
        }
        static void Display()
        {
            foreach (string item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
