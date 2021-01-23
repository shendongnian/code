    class CustomResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            if (objectType == typeof(Rectangle))
            {
                JsonContract contract = base.CreateStringContract(objectType);
                contract.Converter = new RectangleConverter();
                return contract;
            }
            return base.CreateContract(objectType);
        }
    }
