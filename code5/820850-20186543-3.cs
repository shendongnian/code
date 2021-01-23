    public dynamic GetMapperObject(Type enumType)
    {
      Type enumMapperType = typeof(EnumMapper<>)
                               .GetGenericTypeDefinition()
                               .MakeGenericType(enumType);
      var mapper = Activator.CreateInstance(enumMapperType);
      return mapper;
    }
