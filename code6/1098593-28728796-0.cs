    public static class YamlUtils
    {
        public static ExpandoObject ToExpando(string yaml)
        {
            using (var sr = new StringReader(yaml))
            {
                var stream = new YamlStream();
                stream.Load(sr);
                var firstDocument = stream.Documents[0].RootNode;
                dynamic exp = ToExpando(firstDocument);
                return exp;
            }
        }
        public static ExpandoObject ToExpando(YamlNode node)
        {
            ExpandoObject exp = new ExpandoObject();
            exp = (ExpandoObject)ToExpandoImpl(exp, node);
            return exp;
        }
        static object ToExpandoImpl(ExpandoObject exp, YamlNode node)
        {
            YamlScalarNode scalar = node as YamlScalarNode;
            YamlMappingNode mapping = node as YamlMappingNode;
            YamlSequenceNode sequence = node as YamlSequenceNode;
            if (scalar != null)
            {
                string val = scalar.Value;
                return val;
            }
            else if (mapping != null)
            {
                foreach (KeyValuePair<YamlNode, YamlNode> child in mapping.Children)
                {
                    YamlScalarNode keyNode = (YamlScalarNode)child.Key;
                    string keyName = keyNode.Value;
                    object val = ToExpandoImpl(exp, child.Value);
                    var expDict = exp as IDictionary<string, object>;
                    expDict[keyName] = val;
                }
            }
            else if (sequence != null)
            {
                var childNodes = new List<ExpandoObject>();
                foreach (YamlNode child in sequence.Children)
                {
                    var childExp = new ExpandoObject();
                    childExp = (ExpandoObject)ToExpandoImpl(childExp, child);
                    childNodes.Add(childExp);
                }
                return childNodes;
            }
            return exp;
        }
    }
