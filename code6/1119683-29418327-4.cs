    class Program
    {
        // Contains the elements of an line after it's been parsed.
        static string[] array;
        static void Main(string[] args)
        {
            // Read the lines of a file into a list of strings. Iterate through each
            // line and create an array of elements by parsing (splitting) the line by a delimiter (eg. a comma).
            // Then display what's now contained within the array of strings.
            var lines = ReadFile("dummy.txt");
            foreach (string line in lines)
            {
                array = CreateArray(line);
                Display();
            }
            // Prevent the console window from closing.
            Console.ReadLine();
        }
        // Reads a file and returns an array of strings.
        static List<string> ReadFile(string fileName)
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
            return lines;
        }
        // Create an array of string elements from a comma delimited string.
        static string[] CreateArray(string line)
        {
            return line.Split(',');
        }
        // Display the results to the console window for demonstration.
        static void Display()
        {
            foreach (string item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
