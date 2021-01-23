    [XmlIgnore()]
    public Font Font {
      get { return mFont; }
      set { mFont = value; }
    }
    [Browsable(false)]
    public string FontHidden {
      get { return FontSerializationHelper.Serialize(mFont); }
      set { mFont = FontSerializationHelper.Deserialize(value); }
    }
