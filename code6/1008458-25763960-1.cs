            ObservableCollectionExt o = ObservableCollectionExt.Create();
    		JsonSerializerSettings settings = new JsonSerializerSettings();
    		settings.Converters.Add(new MyCustomConverter());
    		string serialized = JsonConvert.SerializeObject(o, settings);
    		ObservableCollectionExt deserialized = JsonConvert.DeserializeObject<ObservableCollectionExt>(serialized, settings);
