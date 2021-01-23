    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.IO.Compression;
     
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string sFileToZip = @"C:\Documents and Settings\My Documents\Visual Studio 2008\Projects\ConsoleApplication1\bin\Debug\Stuff\text1.txt";
                string sZipFile = @"C:\Documents and Settings\My Documents\Visual Studio 2008\Projects\ConsoleApplication1\bin\Debug\Stuff\text1.zip";
     
                using (FileStream __fStream = File.Open(sZipFile, FileMode.Create))
                {
                    GZipStream obj = new GZipStream(__fStream, CompressionMode.Compress);
     
                    byte[] bt = File.ReadAllBytes(sFileToZip);
                    obj.Write(bt, 0, bt.Length);
     
                    obj.Close();
                    obj.Dispose();
                }
            }
        }
    }
