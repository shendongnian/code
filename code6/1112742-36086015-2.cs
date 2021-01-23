    public class Class2Converter : DefaultTypeConverter
    {
        public override string ConvertToString(TypeConverterOptions options, object model)
        {
            var result = string.Empty;
    
            var classObject = model as Class2;
    
            if (classObject != null)
            {
                result = string.Format("{0},{1}", classObject.Field3, classObject.Field4);
            }
    
            return result;
        }
    }
