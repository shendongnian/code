    public static class JsonExtensions
    {
        public static void RemovePropertiesByValue(this JToken root, Predicate<JValue> filter)
        {
            var nulls = root.DescendantsAndSelf().OfType<JValue>().Where(v => v.Parent is JProperty && filter(v)).ToList();
            foreach (var value in nulls)
            {
                var parent = (JProperty)value.Parent;
                parent.Remove();
            }
        }
        public static IEnumerable<JToken> DescendantsAndSelf(this JToken node)
        {
            if (node == null)
                return Enumerable.Empty<JToken>();
            var container = node as JContainer;
            if (container != null)
                return container.DescendantsAndSelf();
            else
                return new [] { node };
        }
    }
