    public class CustomContractResolver : DefaultContractResolver
    {
        private static readonly JsonConverter _converter = new MyCustomConverter();
        private static Type _type = typeof (MyCustomType);
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if (objectType == null || !_type.IsAssignableFrom(objectType)) // alternatively _type == objectType
            {
                return base.ResolveContractConverter(objectType);
            }
            return _converter;
        }
    }
