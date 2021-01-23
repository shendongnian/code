    public static class JsonExtensions
    {
        public static IEnumerable<JToken> WalkTokens(this JToken node)
        {
            if (node == null)
                yield break;
            yield return node;
            foreach (var child in node.Children())
                foreach (var childNode in child.WalkTokens())
                    yield return childNode;
        }
    }
