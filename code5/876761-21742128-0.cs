    class Program
    {
        // Method for output to screen
        public static void OutputToScreen(string theText)
        {
            Console.WriteLine(theText);
        }
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
            OutputToScreen("This is not a delegate demo");
        }
    }
