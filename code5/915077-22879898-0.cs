    [ProtoMember(1, DataFormat = DataFormat.FixedSize)]
    public DateTime DT;
    [ProtoMember(2,)]
    public double BidPrice;
    [ProtoMember(3)]
    public double AskPrice;
    [ProtoMember(4, DataFormat = DataFormat.FixedSize)]
    public int BidSize;
    [ProtoMember(5, DataFormat = DataFormat.FixedSize)]
    public int AskSize;
