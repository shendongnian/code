    public static class YamlUtils
    {
        /// <summary>
        /// Converts a YAML string to an <code>ExpandoObject</code>.
        /// </summary>
        /// <param name="yaml">The YAML string to convert.</param>
        /// <returns>Converted object.</returns>
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
        /// <summary>
        /// Converts a YAML node to an <code>ExpandoObject</code>.
        /// </summary>
        /// <param name="node">The node to convert.</param>
        /// <returns>Converted object.</returns>
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
                // TODO: Try converting to double, DateTime and return that.
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
                    exp.SetProperty(keyName, val);
                }
            }
            else if (sequence != null)
            {
                var childNodes = new List<object>();
                foreach (YamlNode child in sequence.Children)
                {
                    var childExp = new ExpandoObject();
                    object childVal = ToExpandoImpl(childExp, child);
                    childNodes.Add(childVal);
                }
                return childNodes;
            }
            return exp;
        }
    }
