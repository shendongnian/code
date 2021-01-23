    class CustomResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            JsonContract contract = base.CreateContract(objectType);
            if (objectType == typeof(Foo))
            {
                contract.Converter = new FooConverter();
            }
            return contract;
        }
    }
