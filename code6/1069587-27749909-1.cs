        public static IEnumerable<JToken> WalkNodes(this JToken node)
        {
            if (node == null)
            {
                yield break;
            }
            yield return node;
            foreach (JToken child in node.Children())
            {
                foreach (var childNode in child.WalkNodes())
                    yield return childNode;
            }
        }
        public static IDictionary<string, JValue> ToJValueDictionary(this JToken root)
        {
            return root.WalkNodes().OfType<JValue>().ToDictionary(value => value.Path);
        }
        public static IDictionary<string, object> ToValueDictionary(this JToken root)
        {
            return root.WalkNodes().OfType<JValue>().ToDictionary(value => value.Path, value => value.Value);
        }
