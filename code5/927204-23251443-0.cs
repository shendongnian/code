    class Jim
    {
       ...Member variables...
       public static GetMember(String name)
       {
          FieldInfo requestedField = typeof(Jim).GetField(name);
          return requestedField.GetValue(null);
       }
    }
