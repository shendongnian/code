    var typeValue = bindingContext.ValueProvider.GetValue(bindingContext.ModelName + ".ModelType");
    if (typeValue == null)
    {
        var enumerable = (IEnumerable)bindingContext.ValueProvider;
        var formValueProvider = enumerable.OfType<FormValueProvider>().Single();
        var field = typeof(NameValueCollectionValueProvider).GetField(
                        "_values", 
                        BindingFlags.NonPublic | BindingFlags.Instance
                    );
        var dictionary = (IDictionary)field.GetValue(formValueProvider);
        var keys = (IEnumerable<string>)dictionary.Keys;
        var key = keys.FirstOrDefault(x => x.EndsWith(".ModelType"));
        typeValue = bindingContext.ValueProvider.GetValue(key);
    }
