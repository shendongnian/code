    interface IFileConversion
    {
        bool Convert (string inputFile, string outputFile);
        string Description { get; }
    }
