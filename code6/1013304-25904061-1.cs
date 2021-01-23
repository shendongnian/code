    static BaseStringEnum()
    {
        var StringEnumTypes = AppDomain.CurrentDomain.GetAssemblies()
              .SelectMany(a => a.GetTypes())
              .Where(type => type.IsSubclassOf(typeof(BaseStringEnum<T>)));
                
        var InvalidEnumMembers = StringEnumTypes.SelectMany(
                type => type.GetFields()
                        .Where(field => field.FieldType == type || field.IsStatic)
            ).Where(enum_member => string.IsNullOrWhiteSpace((enum_member.GetValue(null) as BaseStringEnum<T>).Value)).ToArray();
                
        if (InvalidEnumMembers.Length > 0) 
           throw new Exception("Some string enums have been declared in the wrong way");
    } 
