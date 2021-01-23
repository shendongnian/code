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
            StreamWriter fileWriter = File.CreateText("delegatedemo.txt");
            fileWriter.WriteLine(theText);
            fileWriter.Flush();
            fileWriter.Close();
        }
        public static void Main()
        {
            Display("This is a delegate demo", 1);
            Display("This is a delegate demo", 2);
        }
        public static void Display(string theText, int type)
        {
            if( type == 1)
                WriteToFile(theText);
            else if( type == 1)
                OutputToScreen(theText);
        }
    }
