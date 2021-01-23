        public static ITag GetByTagName(string tagName)
        {
            var type = typeof(ITag).Assembly.GetTypes().SingleOrDefault(t => string.Equals(t.Name, tagName, StringComparison.OrdinalIgnoreCase));
            if (type == null)
                return null;
            return (ITag) Activator.CreateInstance(type);
        }
        public static bool IsValidTagName(string tagName)
        {
            return GetByTagName(tagName) != null;
        }
