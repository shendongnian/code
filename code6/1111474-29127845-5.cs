    /// <summary>
    /// Custom XmlWriter.
    /// Wraps up another XmlWriter to intercept string writes within
    /// elements and writes them as CDATA instead.
    /// </summary>
    public class XmlCDataWriter : XmlWriter
    {
        XmlWriter w;
    
        public XmlCDataWriter(XmlWriter baseWriter)
        {
            this.w = baseWriter;
        }
    
        public override void Close()
        {
            w.Close();
        }
    
        public override void Flush()
        {
            w.Flush();
        }
    
        public override string LookupPrefix(string ns)
        {
            return w.LookupPrefix(ns);
        }
    
        public override void WriteBase64(byte[] buffer, int index, int count)
        {
            w.WriteBase64(buffer, index, count);
        }
    
        public override void WriteCData(string text)
        {
            w.WriteCData(text);
        }
    
        public override void WriteCharEntity(char ch)
        {
            w.WriteCharEntity(ch);
        }
    
        public override void WriteChars(char[] buffer, int index, int count)
        {
            w.WriteChars(buffer, index, count);
        }
    
        public override void WriteComment(string text)
        {
            w.WriteComment(text);
        }
    
        public override void WriteDocType(string name, string pubid, string sysid, string subset)
        {
            w.WriteDocType(name, pubid, sysid, subset);
        }
    
        public override void WriteEndAttribute()
        {
            w.WriteEndAttribute();
        }
    
        public override void WriteEndDocument()
        {
            w.WriteEndDocument();
        }
    
        public override void WriteEndElement()
        {
            w.WriteEndElement();
        }
    
        public override void WriteEntityRef(string name)
        {
            w.WriteEntityRef(name);
        }
    
        public override void WriteFullEndElement()
        {
            w.WriteFullEndElement();
        }
    
        public override void WriteProcessingInstruction(string name, string text)
        {
            w.WriteProcessingInstruction(name, text);
        }
    
        public override void WriteRaw(string data)
        {
            w.WriteRaw(data);
        }
    
        public override void WriteRaw(char[] buffer, int index, int count)
        {
            w.WriteRaw(buffer, index, count);
        }
    
        public override void WriteStartAttribute(string prefix, string localName, string ns)
        {
            w.WriteStartAttribute(prefix, localName, ns);
        }
    
        public override void WriteStartDocument(bool standalone)
        {
            w.WriteStartDocument(standalone);
        }
    
        public override void WriteStartDocument()
        {
            w.WriteStartDocument();
        }
    
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            w.WriteStartElement(prefix, localName, ns);
        }
    
        public override WriteState WriteState
        {
            get { return w.WriteState; }
        }
    
        public override void WriteString(string text)
        {
            if (WriteState == WriteState.Element)
            {
                w.WriteCData(text);
            }
            else
            {
                w.WriteString(text);
            }
        }
    
        public override void WriteSurrogateCharEntity(char lowChar, char highChar)
        {
            w.WriteSurrogateCharEntity(lowChar, highChar);
        }
    
        public override void WriteWhitespace(string ws)
        {
            w.WriteWhitespace(ws);
        }
    }
