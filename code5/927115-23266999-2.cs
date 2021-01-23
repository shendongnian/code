        public static bool IsCollection(this ModelMetadata metaData)
        {
            if (metaData.ModelType == typeof(string))
            {
                return false;
            }
            return typeof(IEnumerable).IsAssignableFrom(metaData.ModelType);
        }
