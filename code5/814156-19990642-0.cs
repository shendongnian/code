    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(@"C:\mydir\", "*.pdf");
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                var tokens = fileName.Split('-', '_');
                for(int i=0;i<tokens.Length;i++)
                {
                    string token = tokens[i];
                    Console.WriteLine("{0}-{1}", i, token);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
