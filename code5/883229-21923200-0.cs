    class CustomResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            if (objectType == typeof(Rectangle))
            {
                return base.CreateObjectContract(objectType);
            }
            return base.CreateContract(objectType);
        }
    }
