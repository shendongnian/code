        public static IEnumerable<JToken> WalkNodes(this JToken node)
        {
            if (node == null)
            {
                yield break;
            }
            else if (node.Type == JTokenType.Object)
            {
                yield return node;
                foreach (JProperty child in node.Children<JProperty>())
                {
                    foreach (var childNode in child.Value.WalkNodes())
                        yield return childNode;
                }
            }
            else if (node.Type == JTokenType.Array)
            {
                foreach (JToken child in node.Children())
                {
                    foreach (var childNode in child.WalkNodes())
                        yield return childNode;
                }
            }
            else
            {
                yield return node;
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
