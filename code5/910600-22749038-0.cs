    using System;
    using System.IO;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.BufferHeight = 500;
                listDirec(@"c:\program files", 1, 2);
                Console.ReadKey();
            }
            static void listDirec(string path, int start, int end)
            {
                var dirInfo = new DirectoryInfo(path);
                var folders = dirInfo.GetDirectories().ToList();
                foreach (var item in folders)
                {
                    Console.WriteLine("".PadLeft(start * 4, ' ') + item.Name);
                    if (start < end)
                        listDirec(item.FullName, start + 1, end);
                }
            }
        }
    }
