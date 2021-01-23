    public static class JTokenExtensions
    {
        public static JToken RemoveNulls(this JToken node)
        {
            var children = node.Children().ToArray();
            var nonTrivialChildren = children.Select(c => RemoveNulls(c)).Any(v => v != null);
            if (nonTrivialChildren)
                return node;
            // once trivial children are removed, values will be different
            var values = node.Values().ToArray();
            var nonTrivialValues = values.Any(v => v != null);
            if (nonTrivialValues)
                return node;
            // the parent needs to be removed instead
            switch (node.Type)
            {
                case JTokenType.Boolean:
                case JTokenType.Date:
                case JTokenType.Float:
                case JTokenType.Integer:
                case JTokenType.String:
                    return node;
                case JTokenType.Array:
                case JTokenType.Object:
                    return null;
                case JTokenType.Null:
                    break;
            }
            node.Remove();
            return null;
        }
    }
