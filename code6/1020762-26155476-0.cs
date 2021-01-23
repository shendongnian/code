    Console.Write("Enter File Name To Pad: ");
    string fileName = Console.ReadLine();
    Console.Write("Enter Number of Bytes to Pad: ");
    int bytesToPad = Int.Parse(Console.ReadLine());
    using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.None))
    {
        byte[] emptyBytes = new byte[bytesToPad];
        fs.Write(emptyBytes, 0, emptyBytes.Length);
    }
