    int bytesRead;
    while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0)
    {
        Console.WriteLine("bufferlength " + buffer.Where(x => x != 0)
                                                      .ToArray().Length);
        Console.WriteLine(new FileInfo(@"D:\Temp\test2.txt").Length);
        outputStream.Write(buffer, 0, bytesRead); <- HERE
        outputStream.Flush();
    }
