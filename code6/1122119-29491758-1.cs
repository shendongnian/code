    Mapper.CreateMap<object, object>().ConvertUsing(src =>
    {
        if (src is SourceDataType)
            return new DestinationDataType(); // Put your conversion code here.
        else
            return src;
    });
