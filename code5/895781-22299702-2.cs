    public static void Main(string[] args)
    {
        // your command line arguments will be in args
        using (var stream = new BinaryReader(System.IO.File.OpenRead(args[0])))
        {
            while (stream.BaseStream.Position < stream.BaseStream.Length)
            {
                // all sorts of functions for reading here:
                byte processingValue = stream.ReadByte();
            }
        }
    }
