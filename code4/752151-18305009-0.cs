    public Stream GetResourceStream(string filename)
    {
        Assembly asm = Assembly.GetExecutingAssembly();
        string resname = asm.GetName().Name + "." + filename;
        return asm.GetManifestResourceStream(resname);
    }
    ...
    Stream mp3file = GetResourceStream("some file.mp3");
    Mp3FileReader mp3reader = new Mp3FileReader(mp3file);
