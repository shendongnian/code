    public struct SerializableKeyValuePair<T1, T2>
    {
        public T1 Key;
        public T2 Value;
        public SerializableKeyValuePair(T1 key, T2 value)
        {
            Key = key;
            Value = value;
        }
        public SerializableKeyValuePair(XmlElement element)
        {
            Key = element.LocalName;
            var textNode = element.SelectSingleNode("text()");
            // Here you are also not limited to just text, since you have an actual Element, 
            // you could attempt to try and implement deserializing custom classes/objects.
            if (textNode != null)
                Value = SomeConvertForT2(textNode.Value);
        }
    }
