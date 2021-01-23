    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Original Directory Contents  : ");
            string[] fileEntries = Directory.GetFiles(@"C:\Test\stuff");
            foreach (string fileName in fileEntries) 
                Console.WriteLine(fileName);
            Console.WriteLine("Moving Directory... ");
            Directory.Move(@"C:\Test\stuff", @"C:\Test\stuff2");
            Console.WriteLine("Creating New File... ");
            File.WriteAllText(@"C:\Test\stuff2\new.txt", "test");
            Console.WriteLine("New Directory Contents  : ");
            fileEntries = Directory.GetFiles(@"C:\Test\stuff2");
            foreach (string fileName in fileEntries)
                Console.WriteLine(fileName);
            
            Console.WriteLine("Moving Directory... ");
            Directory.Move(@"C:\Test\stuff2", @"C:\Test\stuff");
            fileEntries = Directory.GetFiles(@"C:\Test\stuff");
            foreach (string fileName in fileEntries)
                Console.WriteLine(fileName);
        }
    }
