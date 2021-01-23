    using System;
    using System.IO;
    namespace FilePathWithNotepad__
    {
        class Program
        {
            static void Main(string[] args)
            {
                string originalFilePath = Environment.CurrentDirectory + "\\myFile.txt";
                string title = Path.GetFileNameWithoutExtension(originalFilePath);
                string content = File.ReadAllText(originalFilePath);
                string newfile = Path.GetFileName(Environment.CurrentDirectory + "\\new.txt");
                File.WriteAllText(newfile,content);
            }
        }
    }
 
