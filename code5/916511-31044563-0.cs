    public class JsonObservableCollectionConverter : DefaultContractResolver
    {
        public JsonObservableCollectionConverter(bool shareCache) : base(shareCache)
        {
        }
        public override JsonContract ResolveContract(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ICollection<>))
            {
                return ResolveContract(typeof(ObservableCollection<>).MakeGenericType(type.GetGenericArguments()));
            }
            return base.ResolveContract(type);
        }
    }
	var settings = new JsonSerializerSettings
	{
		ContractResolver = new JsonObservableCollectionConverter(true),
	};
	var result = JsonConvert.DeserializeObject<IEnumerable<TResult>>(json, settings);
