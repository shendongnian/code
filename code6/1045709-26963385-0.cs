    public class IDestConverter : TypeConverter<Source, IDest>
    {
        protected override IDest ConvertCore(Source src)
        {
            IDest result = null;
            
            if (src.Value1 != null)
            {
                result = new DestinationSimple
                {
                    Value1 = src.Value1
                };
            }
            else 
            {
                result = new DestinationComplex
                {
                    Value2 = src.Value2,
                    Values = Mapper.Map<IDest[]>(src.Values)
                };
            }
            
            return result;
        }
    }
