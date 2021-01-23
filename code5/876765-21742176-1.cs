    class Program {
        enum WriteType { ToScreen, ToFile };
        // Method for output to screen
        public static void OutputToScreen(string theText) {
            Console.WriteLine(theText);
        }
        // Method to output to file
        public static void WriteToFile(string theText) {
            StreamWriter fileWriter = File.CreateText("nondelegatedemo.txt");
            fileWriter.WriteLine(theText);
            fileWriter.Flush();
            fileWriter.Close();
        }
        public static void Main() {
            Display("This is a non-delegate demo", WriteType.ToFile);
            Display("This is a non-delegate demo", WriteType.ToScreen);
        }
        public static void Display(string theText, WriteType outputMethod) {
            switch (outputMethod) {
            case WriteType.ToFile: WriteToFile(theText); break;
            case WriteType.ToScreen: WriteToScreen(theText); break;
            }
        }
    }
