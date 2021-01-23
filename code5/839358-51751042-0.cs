   	/// <summary>
	/// XmlWriter that ensures the namespace declarations in the root element are always sorted.
	/// </summary>
	class SortedNamespaceXmlWriter : XmlWriter
	{
		private readonly XmlWriter _baseWriter;
		private readonly List<(string prefix, string uri)> _namespaces = new List<(string prefix, string uri)>();
		private int _elementIndex;
		private string _nsPrefix;
		private bool _inXmlNsAttribute;
		public SortedNamespaceXmlWriter(XmlWriter baseWriter) => _baseWriter = baseWriter;
		public override void WriteStartElement(string prefix, string localName, string ns)
		{
			_elementIndex++;
			FlushRootElementAttributesIfNeeded();
			_baseWriter.WriteStartElement(prefix, localName, ns);
		}
		public override void WriteStartAttribute(string prefix, string localName, string ns)
		{
			if (prefix == "xmlns")
			{
				_inXmlNsAttribute = true;
				_nsPrefix = localName;
			}
			else
			{
				FlushRootElementAttributesIfNeeded();
				_baseWriter.WriteStartAttribute(prefix, localName, ns);
			}
		}
		public override void WriteEndAttribute()
		{
			if (_inXmlNsAttribute)
				_inXmlNsAttribute = false;
			else
				_baseWriter.WriteEndAttribute();
		}
		public override void WriteString(string text)
		{
			if (_inXmlNsAttribute)
				_namespaces.Add((_nsPrefix, text));
			else
				_baseWriter.WriteString(text);
		}
		private void FlushRootElementAttributesIfNeeded()
		{
			if (_elementIndex != 1 || _namespaces.Count == 0)
				return;
			_namespaces.Sort((a, b) => StringComparer.Ordinal.Compare(a.prefix, b.prefix));
			foreach (var (prefix, uri) in _namespaces)
			{
				_baseWriter.WriteStartAttribute("xmlns", prefix, null);
				_baseWriter.WriteString(uri);
				_baseWriter.WriteEndAttribute();
			}
			_namespaces.Clear();
		}
		public override WriteState WriteState => _baseWriter.WriteState;
		public override void Flush() => _baseWriter.Flush();
		public override string LookupPrefix(string ns) => _baseWriter.LookupPrefix(ns);
		public override void WriteBase64(byte[] buffer, int index, int count)
		{
			FlushRootElementAttributesIfNeeded();
			_baseWriter.WriteBase64(buffer, index, count);
		}
		public override void WriteCData(string text)
		{
			FlushRootElementAttributesIfNeeded();
			_baseWriter.WriteCData(text);
		}
		public override void WriteCharEntity(char ch)
		{
			FlushRootElementAttributesIfNeeded();
			_baseWriter.WriteCharEntity(ch);
		}
		public override void WriteChars(char[] buffer, int index, int count)
		{
			FlushRootElementAttributesIfNeeded();
			_baseWriter.WriteChars(buffer, index, count);
		}
		public override void WriteComment(string text)
		{
			FlushRootElementAttributesIfNeeded();
			_baseWriter.WriteComment(text);
		}
		public override void WriteDocType(string name, string pubid, string sysid, string subset) => _baseWriter.WriteDocType(name, pubid, sysid, subset);
		public override void WriteEndDocument() => _baseWriter.WriteEndDocument();
		public override void WriteEndElement()
		{
			FlushRootElementAttributesIfNeeded();
			_baseWriter.WriteEndElement();
		}
		public override void WriteEntityRef(string name)
		{
			FlushRootElementAttributesIfNeeded();
			_baseWriter.WriteEntityRef(name);
		}
		public override void WriteFullEndElement()
		{
			FlushRootElementAttributesIfNeeded();
			_baseWriter.WriteFullEndElement();
		}
		public override void WriteProcessingInstruction(string name, string text)
		{
			FlushRootElementAttributesIfNeeded();
			_baseWriter.WriteProcessingInstruction(name, text);
		}
		public override void WriteRaw(char[] buffer, int index, int count)
		{
			FlushRootElementAttributesIfNeeded();
			_baseWriter.WriteRaw(buffer, index, count);
		}
		public override void WriteRaw(string data)
		{
			FlushRootElementAttributesIfNeeded();
			_baseWriter.WriteRaw(data);
		}
		public override void WriteStartDocument() => _baseWriter.WriteStartDocument();
		public override void WriteStartDocument(bool standalone) => _baseWriter.WriteStartDocument();
		public override void WriteSurrogateCharEntity(char lowChar, char highChar)
		{
			FlushRootElementAttributesIfNeeded();
			_baseWriter.WriteSurrogateCharEntity(lowChar, highChar);
		}
		public override void WriteWhitespace(string ws)
		{
			FlushRootElementAttributesIfNeeded();
			_baseWriter.WriteWhitespace(ws);
		}
	}
