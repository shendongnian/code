    class Program
    {
        // Method to output to file
        public static void WriteToFile(string theText)
        {
            StreamWriter fileWriter = File.CreateText("theFile.txt");
            fileWriter.WriteLine(theText);
            fileWriter.Flush();
            fileWriter.Close();
        }
        public static void Main()
        {
            WriteToFile("This is not a delegate demo");
            Console.WriteLine("This is not a delegate demo");
        }
    }
