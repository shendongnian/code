    using System.IO;
    public class Log
    {
        public static void Message(string message)
        {
            using (StreamWriter writer = File.AppendText("path_to_dir\\log.txt"))
            {
                writer.WriteLine(message);
            }
        }
    }
