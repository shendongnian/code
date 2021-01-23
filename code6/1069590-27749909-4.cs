        public static IEnumerable<JToken> WalkTokens(this JToken node)
        {
            if (node == null)
                yield break;
            yield return node;
            foreach (var child in node.Children())
                foreach (var childNode in child.WalkTokens())
                    yield return childNode;
        }
        public static IDictionary<string, object> ToValueDictionary(this JToken root)
        {
            return root.WalkTokens().OfType<JValue>().ToDictionary(value => value.Path, value => value.Value);
        }
