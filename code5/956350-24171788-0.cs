    class JsonConverterExclusionResolver<T> : DefaultContractResolver
    {
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            JsonConverter conv = base.ResolveContractConverter(objectType);
            if (conv != null && conv.GetType() == typeof(T))
            {
                // if something asks for the converter we're excluding,
                // we never heard of it
                return null;
            }
            return conv;
        }
    }
