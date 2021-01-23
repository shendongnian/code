    public class NamedObject {
    
      private Type[] _values;
    
      public NamedObject(Type[] values) {
        _values = values;
      }
    
      public SpecificName1 { get { return _values[0]; } set { _values[0] = value; } }
      public SpecificName2 { get { return _values[1]; } set { _values[1] = value; } }
      public SpecificName3 { get { return _values[2]; } set { _values[2] = value; } }
      public SpecificName4 { get { return _values[3]; } set { _values[3] = value; } }
      public SpecificName5 { get { return _values[4]; } set { _values[4] = value; } }
      public SpecificName6 { get { return _values[5]; } set { _values[5] = value; } }
    
    }
