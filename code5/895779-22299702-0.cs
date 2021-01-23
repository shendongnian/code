    using (var stream = new BinaryReader(System.IO.File.OpenRead(fileNamePath)))
    {
        while (stream.BaseStream.Position < stream.BaseStream.Length)
        {
            // all sorts of functions for reading here:
            byte processingValue = stream.ReadByte();
        }
    }
