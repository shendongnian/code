    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    namespace experiment
    {
        public class Box
        {
            public int x;
            public Box(int a)
            {
                x = a;
            }
            public Box()
            {
            }
        }
        public class XmlList<T> : List<T>, IXmlSerializable
        {
            public XmlSchema GetSchema()
            {
                return null;
            }
            public void ReadXml(XmlReader reader)
            {
                reader.MoveToContent();
                reader.ReadStartElement();
                if (reader.IsEmptyElement)
                    return;
                var ser = new XmlSerializer(typeof(T));
                var nodeType = reader.MoveToContent();
                if (nodeType == XmlNodeType.None)
                    return;
                while (nodeType != XmlNodeType.EndElement)
                {
                    var item = (T)ser.Deserialize(reader);
                    if (item == null)
                        continue;
                    Add(item);
                    nodeType = reader.MoveToContent();
                }
                reader.ReadEndElement();
            }
            public void WriteXml(XmlWriter writer)
            {
                var ser = new XmlSerializer(typeof(T));
                foreach (T item in this)
                {
                    ser.Serialize(writer, item);
                }
            }
        }
        public class Program
        {
            static void Main(string[] args)
            {
                var MainArr = new XmlList<Box>[]
                {
                    new XmlList<Box>
                    {
                        new Box(1),
                        new Box(4)
                    }
                };
                var writer = new XmlSerializer(MainArr.GetType());
                // Make sure to use a 'using' block to ensure that the stream gets closed, even if there was a serialization error.
                using (var fileWrite = new StreamWriter(@"test.xml"))
                {
                    writer.Serialize(fileWrite, MainArr);
                }
            }
        }
    }
