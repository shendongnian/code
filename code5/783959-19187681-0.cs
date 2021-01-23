    private object MessageBodyPropertyFilter(Type type, Stream stream, StreamDeserializerDelegate original)
    {
        PropertyInfo prop;
        if (_messageBodyPropertyMap.TryGetValue(type, out prop))
        {
            var requestDto = type.CreateInstance();
            prop.SetValue(requestDto, original(prop.PropertyType, stream), null);
            return requestDto;
        }
        else
        {
            return original(type, stream);
        }
    }
