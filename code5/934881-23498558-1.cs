    // estimate the average line length in bytes somehow:
    int averageLineLengthBytes = 100;
    // also need to store the current scroll location in "lines"
    int currentScroll = 0;
    using (var binaryReader = new StreamReader(new FileStream(fileName, FileAccess.Read)))
    {
        if (binaryReader.BaseStream.CanSeek)
        {
            // seek the location to read:
            binaryReader.BaseStream.Seek(averageLineLengthBytes * currentScroll, SeekOrigin.Begin);
            // read the next few lines using this command
            binaryReader.ReadLine();
        }
        else
        {
            // revert to a slower implementation here!
        }
    }
