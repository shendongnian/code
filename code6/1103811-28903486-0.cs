    public abstract class XmlStreamingEditorBase
    {
        readonly XmlReader reader;
        readonly XmlWriter writer;
        readonly Predicate<XmlReader> shouldTransform;
        public XmlStreamingEditorBase(XmlReader reader, XmlWriter writer, Predicate<XmlReader> shouldTransform)
        {
            this.reader = reader;
            this.writer = writer;
            this.shouldTransform = shouldTransform;
        }
        protected XmlReader Reader { get { return reader; } }
        protected XmlWriter Writer { get { return writer; } }
        public void Process()
        {
            while (Reader.Read())
            {
                if (Reader.NodeType == XmlNodeType.Element)
                {
                    if (shouldTransform(Reader))
                    {
                        EditCurrentElement();
                        continue;
                    }
                }
                Writer.WriteShallowNode(Reader);
            }
        }
        protected abstract void EditCurrentElement();
    }
    public class XmlStreamingEditor : XmlStreamingEditorBase
    {
        readonly Action<XmlReader, XmlWriter> transform;
        public XmlStreamingEditor(XmlReader reader, XmlWriter writer, Predicate<XmlReader> shouldTransform, Action<XmlReader, XmlWriter> transform)
            : base(reader, writer, shouldTransform)
        {
            this.transform = transform;
        }
        protected override void EditCurrentElement()
        {
            using (var subReader = Reader.ReadSubtree())
            {
                transform(subReader, Writer);
            }
        }
    }
    public class XmlStreamingPatcher
    {
        readonly XmlReader patchReader;
        readonly XmlReader reader;
        readonly XmlWriter writer;
        readonly Predicate<XmlReader> shouldPatchFrom;
        readonly Func<XmlReader, XmlReader, bool> shouldPatchFromTo;
        bool patched = false;
        public XmlStreamingPatcher(XmlReader reader, XmlWriter writer, XmlReader patchReader, Predicate<XmlReader> shouldPatchFrom, Func<XmlReader, XmlReader, bool> shouldPatchFromTo)
        {
            if (reader == null || writer == null || patchReader == null || shouldPatchFrom == null || shouldPatchFromTo == null)
                throw new ArgumentNullException();
            this.reader = reader;
            this.writer = writer;
            this.patchReader = patchReader;
            this.shouldPatchFrom = shouldPatchFrom;
            this.shouldPatchFromTo = shouldPatchFromTo;
        }
        public bool Process()
        {
            patched = false;
            while (patchReader.Read())
            {
                if (patchReader.NodeType == XmlNodeType.Element)
                {
                    if (shouldPatchFrom(patchReader))
                    {
                        var editor = new XmlStreamingEditor(reader, writer, ShouldPatchTo, PatchNode);
                        editor.Process();
                        return patched;
                    }
                }
            }
            return false;
        }
        bool ShouldPatchTo(XmlReader reader)
        {
            return shouldPatchFromTo(patchReader, reader);
        }
        void PatchNode(XmlReader reader, XmlWriter writer)
        {
            using (var subReader = patchReader.ReadSubtree())
            {
                while (subReader.Read())
                {
                    writer.WriteShallowNode(subReader);
                    patched = true;
                }
            }
        }
    }
    public static class XmlReaderExtensions
    {
        public static XName GetElementName(this XmlReader reader)
        {
            if (reader == null)
                return null;
            if (reader.NodeType != XmlNodeType.Element)
                return null;
            string localName = reader.Name;
            string uri = reader.NamespaceURI;
            return XName.Get(localName, uri);
        }
    }
    public static class XmlWriterExtensions
    {
        public static void WriteShallowNode(this XmlWriter writer, XmlReader reader)
        {
            // adapted from http://blogs.msdn.com/b/mfussell/archive/2005/02/12/371546.aspx
            if (reader == null)
                throw new ArgumentNullException("reader");
            if (writer == null)
                throw new ArgumentNullException("writer");
            switch (reader.NodeType)
            {
                case XmlNodeType.Element:
                    writer.WriteStartElement(reader.Prefix, reader.LocalName, reader.NamespaceURI);
                    writer.WriteAttributes(reader, true);
                    if (reader.IsEmptyElement)
                    {
                        writer.WriteEndElement();
                    }
                    break;
                case XmlNodeType.Text:
                    writer.WriteString(reader.Value);
                    break;
                case XmlNodeType.Whitespace:
                case XmlNodeType.SignificantWhitespace:
                    writer.WriteWhitespace(reader.Value);
                    break;
                case XmlNodeType.CDATA:
                    writer.WriteCData(reader.Value);
                    break;
                case XmlNodeType.EntityReference:
                    writer.WriteEntityRef(reader.Name);
                    break;
                case XmlNodeType.XmlDeclaration:
                case XmlNodeType.ProcessingInstruction:
                    writer.WriteProcessingInstruction(reader.Name, reader.Value);
                    break;
                case XmlNodeType.DocumentType:
                    writer.WriteDocType(reader.Name, reader.GetAttribute("PUBLIC"), reader.GetAttribute("SYSTEM"), reader.Value);
                    break;
                case XmlNodeType.Comment:
                    writer.WriteComment(reader.Value);
                    break;
                case XmlNodeType.EndElement:
                    writer.WriteFullEndElement();
                    break;
                default:
                    Debug.WriteLine("unknown NodeType " + reader.NodeType);
                    break;
            }
        }
    }
