    using System;
    using System.Collections.Generic;
    using System.IO;
    
    static class Program
    {
        static void Main(string[] args)
        {
            string pathSource = "test.jpg";
    
    
            using (FileStream fsSource = new FileStream(pathSource, FileMode.Open, FileAccess.Read))
            {
                // Read the source file into a byte array.
                const int BufferSize = 100000; // Your amount to read at a time
                byte[] buffer = new byte[BufferSize];
    
                if (File.Exists(pathSource))
                {
                    Console.WriteLine("File of this name already exist, you want to continue?");
                    System.IO.FileInfo obj = new System.IO.FileInfo(pathSource);
                    pathSource = "Files/" + Guid.NewGuid() + obj.Extension;
                }
    
                int i = 0, offset = 0, bytesRead;
                List<FileInfo> objFileInfo = new List<FileInfo>();
                Guid fileID = Guid.NewGuid();
    
                while (0 != (bytesRead = fsSource.Read(buffer, offset, BufferSize)))
                {
                    var data = new byte[bytesRead];
                    Array.Copy(buffer, data, bytesRead);
    
                    objFileInfo.Add(new FileInfo { FileID = fileID, FileBytes = data, FileByteID = ++i });
                }
    
                foreach (var item in objFileInfo)
                {
                    AppendAllBytes(pathSource, item.FileBytes);
                }
            }
        }
    
        static void AppendAllBytes(string path, byte[] bytes)
        {
            using (var stream = new FileStream(path, FileMode.Append))
            {
                stream.Write(bytes, 0, bytes.Length);
            }
        }
    }
    
    class FileInfo
    {
        public Guid FileID { get; set; }
        public int FileByteID { get; set; }
        public byte[] FileBytes { get; set; }
    }
