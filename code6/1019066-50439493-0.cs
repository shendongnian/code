    public static T[] MapDynamicList<T>(IEnumerable<YOUR_CUSTOM_CLASS> obj)
        {
            var config = new MapperConfiguration(c => c.CreateMissingTypeMaps = true);
            var mapper = config.CreateMapper();
            var newModel = obj.Select(mapper.Map<T>).ToArray();
            return newModel;
        }
