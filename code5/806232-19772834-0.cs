    public class StringToNullableBooleanConverter : 
        ITypeConverter<string, bool?>
    {
        public bool? Convert(ResolutionContext context)
        {
            if (String.IsNullOrEmpty(System.Convert.ToString(context.SourceValue)) 
                || String.IsNullOrWhiteSpace(System.Convert.ToString(context.SourceValue)))
            {
                return default(bool?);
            }
            else
            {
                bool? boolValue=null;
                bool evalBool;
                if (bool.TryParse(context.SourceValue.ToString(), out evalBool))
                {
                    boolValue = evalBool;
                }
                return boolValue;
            }
        }
    }
