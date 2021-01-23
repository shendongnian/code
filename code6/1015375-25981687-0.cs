    public static T ConvertTo<T>(this object source) where T : new()
    {
        Type sourceType = Type.GetType(source); 
        if (IsMapExists(sourceType, typeof(T)))
        {
            return Mapper.Map<T>(source);
        }
        throw new NotImplementedException("type not supported for conversion");
    }
    public static bool IsMapExists(Type source, Type destination)
    {
        return (AutoMapper.Mapper.FindTypeMapFor(source, destination) != null);
    }
