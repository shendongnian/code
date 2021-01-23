    public class XmlSerializationReaderList1 : XmlSerializationReader
    {
        protected override object Deserialize(XmlSerializationReader reader)
        {
            return ((XmlSerializationReaderList1) reader).Read3_ArrayOfFoobar();
        }
        
        // this is the method which do all work, huge part of it is omitted
        public object Read3_ArrayOfFoobar()
        {
            // this.Reader is XmlSerializationReader field of type XmlReader
            this.Reader.ReadStartElement();
            int num2 = (int) this.Reader.MoveToContent();
            int whileIterations = 0;
            int readerCount = this.ReaderCount;
            while ((this.Reader.NodeType == XmlNodeType.EndElement ? 0 : (this.Reader.NodeType != XmlNodeType.None ? 1 : 0)) != 0)
            {
                if (this.Reader.NodeType == XmlNodeType.Element)
                {
                if ((this.Reader.LocalName != this.id3_Foobar ? 0 : (this.Reader.NamespaceURI == this.id2_Item ? 1 : 0)) != 0)
                {
                    if (list == null)
                    this.Reader.Skip();
                    else
                    list.Add(this.Read2_Foobar(true, true));
                }
                else
                    this.UnknownNode((object) null, ":Foobar");
                }
                else
                this.UnknownNode((object) null, ":Foobar");
                int num3 = (int) this.Reader.MoveToContent();
                this.CheckReaderCount
        }
    
        private Foobar Read2_Foobar(bool isNullable, bool checkType) { //... }
    }
