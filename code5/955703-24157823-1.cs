    private bool? _some_value;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"some_value",
        DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool some_value
    {
      get { return _some_value?? default(bool); }
      set { _some_value = value; }
    }
    [global::System.Xml.Serialization.XmlIgnore]
    [global::System.ComponentModel.Browsable(false)]
    public bool some_valueSpecified
    {
      get { return this._some_value != null; }
      set { if (value == (this._some_value== null))
          this._some_value = value ? this.some_value : (bool?)null; }
    }
    private bool ShouldSerializesome_value() { return some_valueSpecified; }
    private void Resetsome_value() { some_valueSpecified = false; }
