    using System;
    using System.IO;
    
    namespace HeaderReader
    {
        class Program
        {
            static void Main(string[] args)
            {
                byte[] bytesFile = new byte[7]; // Read the first 7 Bytes
                using (FileStream FileS = File.OpenRead("MyFile")) //the uploaded file
                {
                    FileS.Read(bytesFile, 0, 7);
                    FileS.Close();
                }
                string data = BitConverter.ToString(bytesFile); //convert data to get info
                Console.WriteLine("This is the data:" + data);
            }
        }
    }
