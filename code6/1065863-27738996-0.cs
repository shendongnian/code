    protected override JsonArrayContract CreateArrayContract(Type objectType)
    {
                var c = base.CreateArrayContract(objectType);
                
                if(objectType == typeof(Object[]))
                    c.ItemTypeNameHandling = TypeNameHandling.None;
                
                return c;
    }
