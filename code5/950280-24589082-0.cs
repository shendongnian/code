    class CustomContractResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            if (objectType == typeof(ListItem))
                return base.CreateObjectContract(objectType);
            return base.CreateContract(objectType);
        }
    }
