    public enum XmlDoctorStatus
    {
        NoFixNeeded,
        FixMade,
        FixFailed
    }
    public class XmlDoctor
    {
        internal class XmlFixData
        {
            public string InitialXml { get; private set; }
            public string FixedXml { get; private set; }
            public int LineNumber { get; private set; }
            public int LinePosition { get; private set; }
            public XmlFixData(string initialXml, string fixedXml, int lineNumber, int linePosition)
            {
                this.InitialXml = initialXml;
                this.FixedXml = fixedXml;
                this.LineNumber = lineNumber;
                this.LinePosition = linePosition;
            }
            public bool ComesAfter(XmlFixData other)
            {
                if (LineNumber > other.LineNumber)
                    return true;
                if (LineNumber == other.LineNumber && LinePosition > other.LinePosition)
                    return true;
                return false;
            }
        }
        internal class XmlFixedException : Exception
        {
            public XmlFixData XmlFixData { get; private set; }
            public XmlFixedException(XmlFixData data)
            {
                this.XmlFixData = data;
            }
        }
        readonly HashSet<XName> childlessNodes;
        public string OriginalXml { get; private set; }
        public XmlDoctor(string xml, IEnumerable<XName> childlessNodes)
        {
            if (xml == null)
                throw new ArgumentNullException();
            this.OriginalXml = xml;
            this.childlessNodes = new HashSet<XName>(childlessNodes);
        }
        List<int> indices = null;
        string passXml = string.Empty;
        bool inPass = false;
        void InitializePass(string xml)
        {
            if (inPass)
                throw new Exception("nested pass");
            ClearElementData();
            TextHelper.NormalizeLines(xml, out passXml, out indices);
            inPass = true;
        }
        void EndPass()
        {
            inPass = false;
            indices = null;
            passXml = string.Empty;
            ClearElementData();
        }
        static int LineNumber(XmlReader reader)
        {
            return ((IXmlLineInfo)reader).LineNumber;
        }
        static int LinePosition(XmlReader reader)
        {
            return ((IXmlLineInfo)reader).LinePosition;
        }
        // Taken from https://stackoverflow.com/questions/1132494/string-escape-into-xml
        public static string XmlEscape(string escaped)
        {
            var replacements = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string,string>("&", "&amp;"),
                new KeyValuePair<string,string>("\"", "&quot;"),
                new KeyValuePair<string,string>("'", "&apos;"),
                new KeyValuePair<string,string>("<", "&lt;"),
                new KeyValuePair<string,string>(">", "&gt;"),
            };
            foreach (var pair in replacements)
                foreach (var index in escaped.IndexesOf(pair.Key, 0).Reverse())
                    if (!replacements.Any(other => string.Compare(other.Value, 0, escaped, index, other.Value.Length, StringComparison.Ordinal) == 0))
                    {
                        escaped = escaped.Substring(0, index) + pair.Value + escaped.Substring(index + 1, escaped.Length - index - 1);
                    }
            return escaped;
        }
        void HandleNode(XmlReader reader)
        {
            // Adapted from http://blogs.msdn.com/b/mfussell/archive/2005/02/12/371546.aspx
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            switch (reader.NodeType)
            {
                case XmlNodeType.Element:
                    HandleStartElement(reader);
                    if (reader.IsEmptyElement)
                    {
                        HandleEndElement(reader);
                    }
                    break;
                case XmlNodeType.Text:
                    HandleText(reader);
                    break;
                case XmlNodeType.Whitespace:
                case XmlNodeType.SignificantWhitespace:
                    break;
                case XmlNodeType.CDATA:
                    break;
                case XmlNodeType.EntityReference:
                    break;
                case XmlNodeType.XmlDeclaration:
                case XmlNodeType.ProcessingInstruction:
                    break;
                case XmlNodeType.DocumentType:
                    break;
                case XmlNodeType.Comment:
                    break;
                case XmlNodeType.EndElement:
                    HandleEndElement(reader);
                    break;
            }
        }
        private void HandleText(XmlReader reader)
        {
            if (string.IsNullOrEmpty(currentElementLocalName) || string.IsNullOrEmpty(currentElementName))
                return;
            var name = XName.Get(currentElementLocalName, currentElementNameSpace);
            if (!childlessNodes.Contains(name))
                return;
            var lineIndex = LineNumber(reader) - 1;
            var charIndex = LinePosition(reader) - 1;
            if (lineIndex < 0 || charIndex < 0)
                return;
            int startIndex = indices[lineIndex] + charIndex;
            // Scan forward in the input string until we find either the beginning of a CDATA section or the end of this element.
            // Patterns to match:  </Name
            // 
            string pattern1 = "</" + currentElementName;
            var index1 = FindElementEnd(passXml, startIndex, pattern1);
            if (index1 < 0)
                return;  // BAD XML.
            string pattern2 = "<![CDATA[";
            var index2 = passXml.IndexOf(pattern2, startIndex);
            int endIndex = (index2 < 0 ? index1 : Math.Min(index1, index2));
            var text = passXml.Substring(startIndex, endIndex - startIndex);
            var escapeText = XmlEscape(text);
            if (escapeText != text)
            {
                if (escapeText != XmlEscape(escapeText))
                {
                    Debug.Assert(escapeText == XmlEscape(escapeText));
                    throw new InvalidOperationException("Escaping error");
                }
                string fixedXml = passXml.Substring(0, startIndex) + escapeText + passXml.Substring(endIndex, passXml.Length - endIndex);
                throw new XmlFixedException(new XmlFixData(passXml, fixedXml, lineIndex + 1, charIndex + 1));
            }
        }
        static bool IsXmlSpace(char ch)
        {
            // http://www.w3.org/TR/2000/REC-xml-20001006#NT-S
            // [3]    	S 	   ::=    	(#x20 | #x9 | #xD | #xA)+
            return ch == '\u0020' || ch == '\u0009' || ch == '\u000D' || ch == '\u000A';
        }
        private static int FindElementEnd(string passXml, int charPos, string tagEnd)
        {
            while (true)
            {
                var index = passXml.IndexOf(tagEnd, charPos);
                if (index < 0)
                    return index;
                int endPos = index + tagEnd.Length;
                if (index + tagEnd.Length >= passXml.Length)
                    return -1; // Bad xml?
                // Now we must have zero or more white space characters and a ">"
                while (endPos < passXml.Length && IsXmlSpace(passXml[endPos]))
                    endPos++;
                if (endPos >= passXml.Length)
                    return -1; // BAD XML;
                if (passXml[endPos] == '>')
                    return index;
                index = endPos;
                // Spurious ending, keep searching.
            }
        }
        string currentElementName = string.Empty;
        string currentElementNameSpace = string.Empty;
        string currentElementLocalName = string.Empty;
        private void HandleStartElement(XmlReader reader)
        {
            currentElementName = reader.Name;
            currentElementLocalName = reader.LocalName;
            currentElementNameSpace = reader.NamespaceURI;
        }
        private void HandleEndElement(XmlReader reader)
        {
            ClearElementData();
        }
        private void ClearElementData()
        {
            currentElementName = string.Empty;
            currentElementNameSpace = string.Empty;
            currentElementLocalName = string.Empty;
        }
        public XmlDoctorStatus TryFix(out string newXml)
        {
            XmlFixData data = null;
            while (true)
            {
                XmlFixData newData;
                var status = TryFixOnePass((data == null ? OriginalXml : data.FixedXml), out newData);
                switch (status)
                {
                    case XmlDoctorStatus.FixFailed:
                        Debug.WriteLine("Could not fix XML");
                        newXml = OriginalXml;
                        return XmlDoctorStatus.FixFailed;
                    case XmlDoctorStatus.FixMade:
                        if (data != null && !newData.ComesAfter(data))
                        {
                            Debug.WriteLine("Warning -- possible infinite loop detected, aborting fix");
                            newXml = OriginalXml;
                            return XmlDoctorStatus.FixFailed;
                        }
                        data = newData;
                        break;  // Try to fix more
                    case XmlDoctorStatus.NoFixNeeded:
                        if (data == null)
                        {
                            newXml = OriginalXml;
                            return XmlDoctorStatus.NoFixNeeded;
                        }
                        else
                        {
                            newXml = data.FixedXml;
                            return XmlDoctorStatus.FixMade;
                        }
                }
            }
        }
        XmlDoctorStatus TryFixOnePass(string xml, out XmlFixData data)
        {
            try
            {
                InitializePass(xml);
                using (var textReader = new DebugStringReader(passXml))
                using (XmlReader reader = XmlReader.Create(textReader))
                {
                    while (true)
                    {
                        bool read = reader.Read();
                        if (!read)
                            break;
                        HandleNode(reader);
                    }
                }
            }
            catch (XmlFixedException ex)
            {
                // Success - a fix was made.
                data = ex.XmlFixData;
                return XmlDoctorStatus.FixMade;
            }
            catch (Exception ex)
            {
                // Failure - the file was not fixed and could not be parsed.
                Debug.WriteLine("Fix Failed: " + ex.ToString());
                data = null;
                return XmlDoctorStatus.FixFailed;
            }
            finally
            {
                EndPass();
            }
            // No fix needed.
            data = null;
            return XmlDoctorStatus.NoFixNeeded;
        }
    }
    public static class TextHelper
    {
        public static void NormalizeLines(string text, out string newText, out List<int> lineIndices)
        {
            var sb = new StringBuilder();
            var indices = new List<int>();
            using (var sr = new StringReader(text))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    indices.Add(sb.Length);
                    sb.AppendLine(line);
                }
            }
            lineIndices = indices;
            newText = sb.ToString();
        }
        public static IEnumerable<int> IndexesOf(this string str, string value, int startAt)
        {
            if (str == null)
                yield break;
            for (int index = startAt, valueLength = value.Length; ; index += valueLength)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    break;
                yield return index;
            }
        }
    }
