    [XmlIgnore]
    public MyEnum EnumValueReal
    {
        get { return _myEnum; }
        set { _myEnum = value; }
    }
    public string EnumValue
    {
         get
         {
             return EnumValueReal.ToString();
         }
         set
         {
             MyEnum result = MyEnum.Unknown;
             Enum.TryParse(value, true, out result);
             EnumValueReal = result;
         }
    }
