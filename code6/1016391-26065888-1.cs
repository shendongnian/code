    using System;
    using System.Linq;
    using System.Xml;
    using System.IO;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                StreamReader fileStream = new StreamReader("input.xml");
                string path = "output.xml";
    
                XmlDocument doc = new XmlDocument { PreserveWhitespace = true };
                doc.Load(fileStream.BaseStream);
    
                // Do some processing...
    
                MyXmlWriter writer = new MyXmlWriter(XmlWriter.Create(path));
                doc.Save(writer);
            }
        }
    
        public class MyXmlWriter : XmlWriter
        {
            private readonly XmlWriter writer;
    
            public MyXmlWriter(XmlWriter writer)
            {
                if (writer == null) throw new ArgumentNullException("writer");
                this.writer = writer;
            }
    
            // Output non-breaking space as character entity
            public override void WriteString(string text)
            {
                string[] parts = text.Split((char)160);
                for (int i = 0; i < parts.Count(); i++)
                {
                    this.writer.WriteString(parts[i]);
                    if (i + 1 < parts.Count())
                        this.writer.WriteRaw("&#160;");
                }
            }
    
            // The rest of the XmlWriter methods implemented using Decorator Pattern
            public override void Close()
            {
                this.writer.Close();
            }
    
            public override string LookupPrefix(string ns)
            {
                return this.writer.LookupPrefix(ns);
            }
    
            public override void Flush()
            {
                this.writer.Flush();
            }
    
            public override WriteState WriteState
            {
                get { return this.writer.WriteState; }
            }
    
            public override void WriteBase64(byte[] buffer, int index, int count)
            {
                this.writer.WriteBase64(buffer, index, count);
            }
    
            public override void WriteRaw(string data)
            {
                this.writer.WriteRaw(data);
            }
    
            public override void WriteRaw(char[] buffer, int index, int count)
            {
                this.writer.WriteRaw(buffer, index, count);
            }
    
            public override void WriteChars(char[] buffer, int index, int count)
            {
                this.writer.WriteChars(buffer, index, count);
            }
    
            public override void WriteSurrogateCharEntity(char lowChar, char highChar)
            {
                this.writer.WriteSurrogateCharEntity(lowChar, highChar);
            }
    
            public override void WriteWhitespace(string ws)
            {
                this.writer.WriteWhitespace(ws);
            }
    
            public override void WriteCharEntity(char ch)
            {
                this.writer.WriteCharEntity(ch);
            }
    
            public override void WriteEntityRef(string name)
            {
                this.writer.WriteEntityRef(name);
            }
    
            public override void WriteProcessingInstruction(string name, string text)
            {
                this.writer.WriteProcessingInstruction(name, text);
            }
    
            public override void WriteComment(string text)
            {
                this.writer.WriteComment(text);
            }
    
            public override void WriteCData(string text)
            {
                this.writer.WriteCData(text);
            }
    
            public override void WriteEndAttribute()
            {
                this.writer.WriteEndAttribute();
            }
    
            public override void WriteStartAttribute(string prefix, string localName, string ns)
            {
                this.writer.WriteStartAttribute(prefix, localName, ns);
            }
    
            public override void WriteFullEndElement()
            {
                this.writer.WriteFullEndElement();
            }
    
            public override void WriteStartElement(string prefix, string localName, string ns)
            {
                this.writer.WriteStartElement(prefix, localName, ns);
            }
    
            public override void WriteEndElement()
            {
                this.writer.WriteEndElement();
            }
    
            public override void WriteDocType(string name, string pubid, string sysid, string subset)
            {
                this.writer.WriteDocType(name, pubid, sysid, subset);
            }
    
            public override void WriteEndDocument()
            {
                this.writer.WriteEndDocument();
            }
    
            public override void WriteStartDocument(bool standalone)
            {
                this.writer.WriteStartDocument(standalone);
            }
    
            public override void WriteStartDocument()
            {
                this.writer.WriteStartDocument();
            }
        }
    }
