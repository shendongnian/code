    public string EnumValue
    {
        get { return _myEnum; }
        set { _myEnum = value; }
    }
    [NonSerialized]
    public MyEnum EnumValueTyped {
      get {
        MyEnum value;
        if (Enum.TryParse<MyEnum>(EnumValue, out value)) {
          return value;
        }
        return MyEnum.Unknown;
      }
      set {
        EnumValue = value.ToString();
      }
    }
