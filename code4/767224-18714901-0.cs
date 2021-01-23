    [Frobber(Offset = 4, Format = DataFormat.LittleEndianInt32)]
    public int Id {get;set;}
    [Frobber(Offset = 0, Format = DataFormat.LittleEndianInt32)]
    public int Index {get;set;}
    [Frobber(Offset = 8, Format = DataFormat.FixedAscii, Size = 20)]
    public string Name {get;set;}
    [Frobber(Offset = 28, Format = DataFormat.Blob)] // implicit Size=16 as Guid
    public Guid UniqueKey {get;set;}
