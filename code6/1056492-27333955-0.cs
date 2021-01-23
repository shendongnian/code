    class CustomResolver : DefaultContractResolver
    {
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            JsonObjectContract contract = base.CreateObjectContract(objectType);
            if (objectType == typeof(ObjectId))
            {
                contract.Converter = new ObjectIdConverter();
            }
            return contract;
        }
    }
