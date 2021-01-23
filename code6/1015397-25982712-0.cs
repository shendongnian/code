    enum MyEnum { a = 5, b = 2, c = 4, d = 1, e = 3 }
    public static int GetFieldIndex(this Enum value)
    {
      Type t = value.GetType();
      var Fields = t.GetFields();
      Fields = Array.FindAll(Fields, f => f.FieldType.Equals(t));
      var typedFields = Array.ConvertAll(Fields, f => f.GetValue(null));
      return Array.IndexOf(typedFields, value);
    }
