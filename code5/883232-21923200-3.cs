    class CustomResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            if (objectType == typeof(Rectangle) || objectType == typeof(Rectangle?))
            {
                JsonContract contract = base.CreateObjectContract(objectType);
                contract.Converter = new RectangleConverter();
                return contract;
            }
            return base.CreateContract(objectType);
        }
    }
