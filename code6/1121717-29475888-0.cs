    public static class JsonExtensions
    {
        public static void RemovePropertyValues(this JToken root, Predicate<JValue> filter)
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
                yield break;
            yield return node;
            foreach (var child in node.Children())
                foreach (var childNode in child.DescendantsAndSelf())
                    yield return childNode;
        }
    }
