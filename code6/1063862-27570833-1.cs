    public class MyObjectType
    {
      [XmlIgnore] public bool BoolValue;  // this is not mapping directly from the xml
      [XmlElement("boolValue")]
      public string BoolInternalValue  // this is mapping directly from the xml and assign the value to the BoolValue property
      {
          get { return BoolValue.ToString(); }
          set
          {
              bool.TryParse(value, out BoolValue);
          }
      }
      ...
