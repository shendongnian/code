    using System;
    using System.IO;
    class Program
    {
        static void Main()
        {
            string path = "C:\\stagelist.txt";
            string extension = Path.GetExtension(path);
            string filename = Path.GetFileName(path);
            string filenameNoExtension = Path.GetFileNameWithoutExtension(path);
            string root = Path.GetPathRoot(path);
        }
    }
