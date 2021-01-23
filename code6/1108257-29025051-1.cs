    using System; using System.IO;
    namespace CreateFile {
    class MainClass
    {
            public static void Main (string[] args)
            {
            Console.WriteLine ("Enter the File name:");
            string filename = Console.ReadLine (); 
            FileInfo fi = new FileInfo(@"G:\New folder (5)\" + filename + ".txt");
            //You can use any extension to create respective file.
                    StreamWriter sw;
                    if (!fi.Exists)
                    {
                        FileStream fs = fi.Create();
                        fs.Close();
                        fs.Dispose();
                    }
            }
        }
    }
