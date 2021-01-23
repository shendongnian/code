    namespace XMLSerializableDictionary
    {
      using System;
      using System.Collections.Generic;
      using System.Runtime.Serialization;
      using System.Xml;
      using System.Xml.Schema;
      using System.Xml.Serialization;
      [Serializable]
      [XmlRoot("Dictionary")]
      public class SerializableDictionary<TKey, TValue>
        : Dictionary<TKey, TValue>, IXmlSerializable
      {
        private const string DefaultTagItem = "Item";
        private const string DefaultTagKey = "Key";
        private const string DefaultTagValue = "Value";
        private static readonly XmlSerializer KeySerializer =
                                        new XmlSerializer(typeof(TKey));
        private static readonly XmlSerializer ValueSerializer =
                                        new XmlSerializer(typeof(TValue));
        public SerializableDictionary() : base()
        {
        }
        protected SerializableDictionary(SerializationInfo info, StreamingContext context)
                : base(info, context)
        {
        }
        protected virtual string ItemTagName
        {
            get { return DefaultTagItem; }
        }
        protected virtual string KeyTagName
        {
            get { return DefaultTagKey; }
        }
        protected virtual string ValueTagName
        {
            get { return DefaultTagValue; }
        }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();
            if (wasEmpty)
            {
             return;
            }
            try
            {
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    reader.ReadStartElement(this.ItemTagName);
                    try
                    {
                        TKey tKey;
                        TValue tValue;
                        reader.ReadStartElement(this.KeyTagName);
                        try
                        {
                            tKey = (TKey)KeySerializer.Deserialize(reader);
                        }
                        finally
                        {
                            reader.ReadEndElement();
                        }
                        reader.ReadStartElement(this.ValueTagName);
                        try
                        {
                            tValue = (TValue)ValueSerializer.Deserialize(reader);
                        }
                        finally
                        {
                            reader.ReadEndElement();
                        }
                        this.Add(tKey, tValue);
                    }
                    finally
                    {
                        reader.ReadEndElement();
                    }
                    reader.MoveToContent();
                }
            }
            finally
            {
                reader.ReadEndElement();
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            foreach (KeyValuePair<TKey, TValue> keyValuePair in this)
            {
                writer.WriteStartElement(this.ItemTagName);
                try
                {
                    writer.WriteStartElement(this.KeyTagName);
                    try
                    {
                        KeySerializer.Serialize(writer, keyValuePair.Key);
                    }
                    finally
                    {
                        writer.WriteEndElement();
                    }
                    writer.WriteStartElement(this.ValueTagName);
                    try
                    {
                        ValueSerializer.Serialize(writer, keyValuePair.Value);
                    }
                    finally
                    {
                        writer.WriteEndElement();
                    }
                }
                finally
                {
                    writer.WriteEndElement();
                }
            }
        }
      }
    }
