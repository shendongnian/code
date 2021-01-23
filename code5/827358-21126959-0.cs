    static IEnumerable<MemberInfo> GetMembers(Type type)
    {
      var properties = type.GetProperties();
      var fields = type.GetFields();
      return properties.Cast<MemberInfo>().Concat(fields);
    }
    static Type GetMemberType(MemberInfo m)
    {
      return m is PropertyInfo
        ? (m as PropertyInfo).PropertyType
        : (m as FieldInfo).FieldType;
    }
