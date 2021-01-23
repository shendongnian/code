    public class Foo<T>
    {
    
        public T Data
        {
            get;
            protected set;
        }
    
        public Foo()
        {
            switch (Type.GetTypeCode(Data.GetType()))
            {
                case TypeCode.Boolean:
                    Data = ConvertValue<T>(true); 
                    break;
                case TypeCode.DateTime:
                    Data = ConvertValue<T>("01/01/2014"); 
                    break;
                case TypeCode.Double:
                    Data = ConvertValue<T>(0.5); 
                    break;
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    Data = ConvertValue<T>(32); 
                    break;
                case TypeCode.String:
                    Data = ConvertValue<T>("Test");
                    break;
                default:
                    break;
            }
    
        }
        private static T ConvertValue<T>(object value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
