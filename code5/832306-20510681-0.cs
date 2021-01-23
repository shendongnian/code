    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(getProgramRootDirectory(@"C:\User\zhenhui\Desktop\AGM\Program\Python1\bin\Debug\"));
                Console.WriteLine(getProgramRootDirectory(@"C:\Users\zhenhui\Downloads\AGM\Program\Python1\bin\Debug\"));
                Console.WriteLine(getProgramRootDirectory(@"C:\AGM\Program\Python1\bin\Debug\"));
                Console.WriteLine(getProgramRootDirectory(@"D:\AGM\Program\Python1\bin\Debug\"));
                Console.WriteLine(getProgramRootDirectory(@"E:\AGM\Program\Python1\bin\Debug\"));
                Console.ReadLine();
            }
            static private string getProgramRootDirectory(string path)
            {
                return path.Replace(@"AGM\Program\Python1\bin\Debug\", "");
            }
        }
    }
