    private bool _some_value = default(bool);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"some_value",
        DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool some_value
    {
      get { return _some_value; }
      set { _some_value = value; }
    }
