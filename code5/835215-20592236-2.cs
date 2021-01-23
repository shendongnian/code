    using (FileStream inputStream = new FileStream(@"C:\Temp\test.txt",
                                                     FileMode.Open))
    {
        using (FileStream outputStream = new FileStream(@"C:\Temp\test2.txt",
                                                          FileMode.OpenOrCreate))
        {
            byte[] buffer = new byte[inputStream.Length];
            Console.WriteLine(new FileInfo(@"C:\Temp\test.txt").Length + "\n");
            int bytesRead;
            while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                Console.WriteLine("bufferlength " + buffer.Where(x => x != 0)
                                                      .ToArray().Length);
                Console.WriteLine(new FileInfo(@"D:\Temp\test2.txt").Length);
                outputStream.Write(buffer, 0, bytesRead); <- HERE
                outputStream.Flush();
             }
            Console.WriteLine("\n" + inputStream.Length);
            Console.WriteLine(outputStream.Length);
        }
    }
