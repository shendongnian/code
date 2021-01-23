    public class TreeNodeParser
    {
        public T ReadNode<T>(T parent, XmlReader reader)
            where T: class, ITreeNode, new()
        {
            if (reader.NodeType == XmlNodeType.Whitespace)
            {
                return null;
            }
            T subNode = new T();
            while (reader.NodeType != XmlNodeType.Element && reader.Read())
            {
            }
            subNode.Tag = reader.Name;
            subNode.Parent = parent;
            if (reader.AttributeCount > 0)
            {
                reader.MoveToFirstAttribute();
                do
                {
                    subNode.SetAttribute(reader.Name, reader.Value);
                } while (reader.MoveToNextAttribute());
            }
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.EndElement)
                {
                    if (string.Equals(subNode.Tag, reader.Name))
                    {
                        break;
                    }
                    continue;
                }
                if (reader.NodeType == XmlNodeType.Element)
                {
                    T child = ReadNode(subNode, reader);
                    if (child != null)
                    {
                        subNode.Children.Add(child);
                    }
                    continue;
                }
                if (reader.NodeType == XmlNodeType.Text)
                {
                    subNode.ValueAsString = reader.Value;
                    continue;
                }
            }
            return subNode;
        }
        public T FromStream<T>(Stream stream)
            where T : class, ITreeNode, new()
        {
            T result = default(T);
            using (XmlReader reader = new XmlTextReader(stream))
            {
                while (reader.Read())
                {
                    T child = ReadNode(result, reader);
                    if (child != null)
                    {
                        result = child;
                    }
                }
            }
            return result;
        }
    }
