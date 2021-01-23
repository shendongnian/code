    class Program
    {
        static void Main(string[] args)
        {
            var test = new OpenFileTest("SomeFile.txt");
            Console.ReadKey();
        }
    }
    public class OpenFileTest
    {
        public OpenFileTest(string path)
        {
            var stream1 = GetFileStream(path);
            var stream2 = GetFileStream(path);  // throws IOException
        }
        private Stream GetFileStream(String path)
        {
            return !File.Exists(path) ? null : File.Open(path, FileMode.Open, FileAccess.Read);
        }
    }
