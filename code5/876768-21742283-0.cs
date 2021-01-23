    interface IWriter {
        public static void Write(string text);
    }
    class FileWriter : IWriter {
        public void Write(string text)
        {
            StreamWriter fileWriter = File.CreateText("delegatedemo.txt");
            fileWriter.WriteLine(theText);
            fileWriter.Flush();
            fileWriter.Close();
        }
    }
    class ConsoleWriter: IWriter {
        public void Write(string text)
        {
            Console.WriteLine(theText);
        }
    }
    public static void Main()
    {
        new FileWriter.Write("This is a NOT delegate demo");
        new ConsoleWriter.Write("This is NOT a delegate demo");
    }
