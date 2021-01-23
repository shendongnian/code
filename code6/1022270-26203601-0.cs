    #if _DYNAMIC_XMLSERIALIZER_COMPILATION
    [assembly:System.Security.AllowPartiallyTrustedCallers()]
    [assembly:System.Security.SecurityTransparent()]
    [assembly:System.Security.SecurityRules(System.Security.SecurityRuleSet.Level1)]
    #endif
    [assembly: System.Reflection.AssemblyVersionAttribute("1.0.0.0")]
    [assembly: System.Xml.Serialization.XmlSerializerVersionAttribute(ParentAssemblyId = @"c80da358-347f-48cf-88a7-0fda1a15c25b,", Version = @"4.0.0.0")]
    namespace Microsoft.Xml.Serialization.GeneratedAssembly
    {
        public class XmlSerializationWriterX : System.Xml.Serialization.XmlSerializationWriter
        {
            public void Write4_X(object o)
            {
                WriteStartDocument();
                if (o == null)
                {
                    WriteNullTagLiteral(@"X", @"");
                    return;
                }
                TopLevelElement();
                Write3_X(@"X", @"", ((global::expirement.X)o), true, false);
            }
            void Write3_X(string n, string ns, global::expirement.X o, bool isNullable, bool needType)
            {
                if ((object)o == null)
                {
                    if (isNullable) WriteNullTagLiteral(n, ns);
                    return;
                }
                if (!needType)
                {
                    System.Type t = o.GetType();
                    if (t == typeof(global::expirement.X))
                    {
                    }
                    else
                    {
                        throw CreateUnknownTypeException(o);
                    }
                }
                WriteStartElement(n, ns, o, false, null);
                if (needType) WriteXsiType(@"X", @"");
                {
                    global::System.Collections.Generic.List<global::expirement.Box>[] a = (global::System.Collections.Generic.List<global::expirement.Box>[])((global::System.Collections.Generic.List<global::expirement.Box>[])o.@Boxes);
                    if (a != null)
                    {
                        WriteStartElement(@"Boxes", @"", null, false);
                        for (int ia = 0; ia < a.Length; ia++)
                        {
                            {
                                global::System.Collections.Generic.List<global::expirement.Box> aa = (global::System.Collections.Generic.List<global::expirement.Box>)((global::System.Collections.Generic.List<global::expirement.Box>)a[ia]);
                                if ((object)(aa) == null)
                                {
                                    WriteNullTagLiteral(@"ArrayOfBox", @"");
                                }
                                else
                                {
                                    WriteStartElement(@"ArrayOfBox", @"", null, false);
                                    for (int iaa = 0; iaa < ((System.Collections.ICollection)aa).Count; iaa++)
                                    {
                                        Write2_Box(@"Box", @"", ((global::expirement.Box)aa[iaa]), true, false);
                                    }
                                    WriteEndElement();
                                }
                            }
                        }
                        WriteEndElement();
                    }
                }
                WriteEndElement(o);
            }
            void Write2_Box(string n, string ns, global::expirement.Box o, bool isNullable, bool needType)
            {
                if ((object)o == null)
                {
                    if (isNullable) WriteNullTagLiteral(n, ns);
                    return;
                }
                if (!needType)
                {
                    System.Type t = o.GetType();
                    if (t == typeof(global::expirement.Box))
                    {
                    }
                    else
                    {
                        throw CreateUnknownTypeException(o);
                    }
                }
                WriteStartElement(n, ns, o, false, null);
                if (needType) WriteXsiType(@"Box", @"");
                WriteElementStringRaw(@"x", @"", System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)o.@x)));
                WriteEndElement(o);
            }
            protected override void InitCallbacks()
            {
            }
        }
        public class XmlSerializationReaderX : System.Xml.Serialization.XmlSerializationReader
        {
            public object Read4_X()
            {
                object o = null;
                Reader.MoveToContent();
                if (Reader.NodeType == System.Xml.XmlNodeType.Element)
                {
                    if (((object)Reader.LocalName == (object)id1_X && (object)Reader.NamespaceURI == (object)id2_Item))
                    {
                        o = Read3_X(true, true);
                    }
                    else
                    {
                        throw CreateUnknownNodeException();
                    }
                }
                else
                {
                    UnknownNode(null, @":X");
                }
                return (object)o;
            }
            global::expirement.X Read3_X(bool isNullable, bool checkType) {
                System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
                bool isNull = false;
                if (isNullable) isNull = ReadNull();
                if (checkType) {
                if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id1_X && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
                }
                else
                    throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
                }
                if (isNull) return null;
                global::expirement.X o;
                o = new global::expirement.X();
                global::System.Collections.Generic.List<global::expirement.Box>[] a_0 = null;
                int ca_0 = 0;
                bool[] paramsRead = new bool[1];
                while (Reader.MoveToNextAttribute()) {
                    if (!IsXmlnsAttribute(Reader.Name)) {
                        UnknownNode((object)o);
                    }
                }
                Reader.MoveToElement();
                if (Reader.IsEmptyElement) {
                    Reader.Skip();
                    return o;
                }
                Reader.ReadStartElement();
                Reader.MoveToContent();
                int whileIterations0 = 0;
                int readerCount0 = ReaderCount;
                while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                    if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                        if (((object) Reader.LocalName == (object)id3_Boxes && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            if (!ReadNull()) {
                                global::System.Collections.Generic.List<global::expirement.Box>[] a_0_0 = null;
                                int ca_0_0 = 0;
                                if ((Reader.IsEmptyElement)) {
                                    Reader.Skip();
                                }
                                else {
                                    Reader.ReadStartElement();
                                    Reader.MoveToContent();
                                    int whileIterations1 = 0;
                                    int readerCount1 = ReaderCount;
                                    while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                                        if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                                            if (((object) Reader.LocalName == (object)id4_ArrayOfBox && (object) Reader.NamespaceURI == (object)id2_Item)) {
                                                if (!ReadNull()) {
                                                    if ((object)(a_0_0 = (global::System.Collections.Generic.List<global::expirement.Box>[])EnsureArrayIndex(a_0_0, ca_0_0, typeof(global::System.Collections.Generic.List<global::expirement.Box>));a_0_0[ca_0_0++]) == null) a_0_0 = (global::System.Collections.Generic.List<global::expirement.Box>[])EnsureArrayIndex(a_0_0, ca_0_0, typeof(global::System.Collections.Generic.List<global::expirement.Box>));a_0_0[ca_0_0++] = new global::System.Collections.Generic.List<global::expirement.Box>();
                                                    global::System.Collections.Generic.List<global::expirement.Box> a_0_0_0 = (global::System.Collections.Generic.List<global::expirement.Box>)a_0_0 = (global::System.Collections.Generic.List<global::expirement.Box>[])EnsureArrayIndex(a_0_0, ca_0_0, typeof(global::System.Collections.Generic.List<global::expirement.Box>));a_0_0[ca_0_0++];
                                                    if ((Reader.IsEmptyElement)) {
                                                        Reader.Skip();
                                                    }
                                                    else {
                                                        Reader.ReadStartElement();
                                                        Reader.MoveToContent();
                                                        int whileIterations2 = 0;
                                                        int readerCount2 = ReaderCount;
                                                        while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                                                            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                                                                if (((object) Reader.LocalName == (object)id5_Box && (object) Reader.NamespaceURI == (object)id2_Item)) {
                                                                    if ((object)(a_0_0_0) == null) Reader.Skip(); else a_0_0_0.Add(Read2_Box(true, true));
                                                                }
                                                                else {
                                                                    UnknownNode(null, @":Box");
                                                                }
                                                            }
                                                            else {
                                                                UnknownNode(null, @":Box");
                                                            }
                                                            Reader.MoveToContent();
                                                            CheckReaderCount(ref whileIterations2, ref readerCount2);
                                                        }
                                                    ReadEndElement();
                                                    }
                                                }
                                                else {
                                                    if ((object)(a_0_0 = (global::System.Collections.Generic.List<global::expirement.Box>[])EnsureArrayIndex(a_0_0, ca_0_0, typeof(global::System.Collections.Generic.List<global::expirement.Box>));a_0_0[ca_0_0++]) == null) a_0_0 = (global::System.Collections.Generic.List<global::expirement.Box>[])EnsureArrayIndex(a_0_0, ca_0_0, typeof(global::System.Collections.Generic.List<global::expirement.Box>));a_0_0[ca_0_0++] = new global::System.Collections.Generic.List<global::expirement.Box>();
                                                    global::System.Collections.Generic.List<global::expirement.Box> a_0_0_0 = (global::System.Collections.Generic.List<global::expirement.Box>)a_0_0 = (global::System.Collections.Generic.List<global::expirement.Box>[])EnsureArrayIndex(a_0_0, ca_0_0, typeof(global::System.Collections.Generic.List<global::expirement.Box>));a_0_0[ca_0_0++];
                                                }
                                            }
                                            else {
                                                UnknownNode(null, @":ArrayOfBox");
                                            }
                                        }
                                        else {
                                            UnknownNode(null, @":ArrayOfBox");
                                        }
                                        Reader.MoveToContent();
                                        CheckReaderCount(ref whileIterations1, ref readerCount1);
                                    }
                                ReadEndElement();
                                }
                                o.@Boxes = (global::System.Collections.Generic.List<global::expirement.Box>[])ShrinkArray(a_0_0, ca_0_0, typeof(global::System.Collections.Generic.List<global::expirement.Box>), false);
                            }
                        }
                        else {
                            UnknownNode((object)o, @":Boxes");
                        }
                    }
                    else {
                        UnknownNode((object)o, @":Boxes");
                    }
                    Reader.MoveToContent();
                    CheckReaderCount(ref whileIterations0, ref readerCount0);
                }
                ReadEndElement();
                return o;
            }
            global::expirement.Box Read2_Box(bool isNullable, bool checkType)
            {
                System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
                bool isNull = false;
                if (isNullable) isNull = ReadNull();
                if (checkType)
                {
                    if (xsiType == null || ((object)((System.Xml.XmlQualifiedName)xsiType).Name == (object)id5_Box && (object)((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item))
                    {
                    }
                    else
                        throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
                }
                if (isNull) return null;
                global::expirement.Box o;
                o = new global::expirement.Box();
                bool[] paramsRead = new bool[1];
                while (Reader.MoveToNextAttribute())
                {
                    if (!IsXmlnsAttribute(Reader.Name))
                    {
                        UnknownNode((object)o);
                    }
                }
                Reader.MoveToElement();
                if (Reader.IsEmptyElement)
                {
                    Reader.Skip();
                    return o;
                }
                Reader.ReadStartElement();
                Reader.MoveToContent();
                int whileIterations3 = 0;
                int readerCount3 = ReaderCount;
                while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None)
                {
                    if (Reader.NodeType == System.Xml.XmlNodeType.Element)
                    {
                        if (!paramsRead[0] && ((object)Reader.LocalName == (object)id6_x && (object)Reader.NamespaceURI == (object)id2_Item))
                        {
                            {
                                o.@x = System.Xml.XmlConvert.ToInt32(Reader.ReadElementString());
                            }
                            paramsRead[0] = true;
                        }
                        else
                        {
                            UnknownNode((object)o, @":x");
                        }
                    }
                    else
                    {
                        UnknownNode((object)o, @":x");
                    }
                    Reader.MoveToContent();
                    CheckReaderCount(ref whileIterations3, ref readerCount3);
                }
                ReadEndElement();
                return o;
            }
            protected override void InitCallbacks()
            {
            }
            string id5_Box;
            string id3_Boxes;
            string id1_X;
            string id2_Item;
            string id6_x;
            string id4_ArrayOfBox;
            protected override void InitIDs()
            {
                id5_Box = Reader.NameTable.Add(@"Box");
                id3_Boxes = Reader.NameTable.Add(@"Boxes");
                id1_X = Reader.NameTable.Add(@"X");
                id2_Item = Reader.NameTable.Add(@"");
                id6_x = Reader.NameTable.Add(@"x");
                id4_ArrayOfBox = Reader.NameTable.Add(@"ArrayOfBox");
            }
        }
        public abstract class XmlSerializer1 : System.Xml.Serialization.XmlSerializer
        {
            protected override System.Xml.Serialization.XmlSerializationReader CreateReader()
            {
                return new XmlSerializationReaderX();
            }
            protected override System.Xml.Serialization.XmlSerializationWriter CreateWriter()
            {
                return new XmlSerializationWriterX();
            }
        }
        public sealed class XSerializer : XmlSerializer1
        {
            public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader)
            {
                return xmlReader.IsStartElement(@"X", @"");
            }
            protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer)
            {
                ((XmlSerializationWriterX)writer).Write4_X(objectToSerialize);
            }
            protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader)
            {
                return ((XmlSerializationReaderX)reader).Read4_X();
            }
        }
        public class XmlSerializerContract : global::System.Xml.Serialization.XmlSerializerImplementation
        {
            public override global::System.Xml.Serialization.XmlSerializationReader Reader { get { return new XmlSerializationReaderX(); } }
            public override global::System.Xml.Serialization.XmlSerializationWriter Writer { get { return new XmlSerializationWriterX(); } }
            System.Collections.Hashtable readMethods = null;
            public override System.Collections.Hashtable ReadMethods
            {
                get
                {
                    if (readMethods == null)
                    {
                        System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                        _tmp[@"expirement.X::"] = @"Read4_X";
                        if (readMethods == null) readMethods = _tmp;
                    }
                    return readMethods;
                }
            }
            System.Collections.Hashtable writeMethods = null;
            public override System.Collections.Hashtable WriteMethods
            {
                get
                {
                    if (writeMethods == null)
                    {
                        System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                        _tmp[@"expirement.X::"] = @"Write4_X";
                        if (writeMethods == null) writeMethods = _tmp;
                    }
                    return writeMethods;
                }
            }
            System.Collections.Hashtable typedSerializers = null;
            public override System.Collections.Hashtable TypedSerializers
            {
                get
                {
                    if (typedSerializers == null)
                    {
                        System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                        _tmp.Add(@"expirement.X::", new XSerializer());
                        if (typedSerializers == null) typedSerializers = _tmp;
                    }
                    return typedSerializers;
                }
            }
            public override System.Boolean CanSerialize(System.Type type)
            {
                if (type == typeof(global::expirement.X)) return true;
                return false;
            }
            public override System.Xml.Serialization.XmlSerializer GetSerializer(System.Type type)
            {
                if (type == typeof(global::expirement.X)) return new XSerializer();
                return null;
            }
        }
    }
