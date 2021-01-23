     public class ByteToInt32Converter : ITypeConverter<byte, int>
        {
            public int Convert(ResolutionContext context)
            {
                return System.Convert.ToInt32(context.SourceValue);
            }
        }
    
    Mapper.CreateMap<byte, int>().ConvertUsing<ByteToInt32Converter>();
    
    // your Company to SelectItem mapping code.
