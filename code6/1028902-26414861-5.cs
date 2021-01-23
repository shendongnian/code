        static IEnumerable<JToken> FindProperties(JToken root)
        {
            return root.WalkNodes().Where(n =>
            {
                var _parent = n.Parent as JProperty;
                if (_parent != null && _parent.Name == "properties")
                {
                    if (n.Count() > 1)
                        return true;
                }
                return false;
            });
        }
        public static IEnumerable<JToken> WalkNodes(this JToken node)
        {
            if (node.Type == JTokenType.Object)
            {
                yield return (JObject)node;
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
        }
