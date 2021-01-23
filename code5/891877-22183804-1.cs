    public class Program
    {
        public static void Main(string[] args)
        {
            File.AppendAllText(pathToLog, string.Format("{0} - File got created in watched folder - doing conversion of {1}\n", DateTime.Now, args[0]));
        }
    }
