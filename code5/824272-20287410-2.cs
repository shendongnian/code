    public class XmlProxyWritter : XmlTextWriter {
      private string m_NS;
      public XmlProxyWritter(string ns, TextWriter w)
        : base(w) {
          m_NS = ns;
      }
      public XmlProxyWritter(string ns, Stream w, Encoding encoding)
        : base(w, encoding) {
          m_NS = ns;
      }
      public XmlProxyWritter(string ns, string filename, Encoding encoding)
        : base(filename, encoding) {
          m_NS = ns;
      }
      public override string LookupPrefix(string ns) {
        if (string.Compare(ns, m_NS, StringComparison.OrdinalIgnoreCase) == 0) {
          return "gto";
        }
        return base.LookupPrefix(ns);
      }
      public override void WriteStartElement(string prefix, string localName, string ns) {
        if (string.IsNullOrEmpty(prefix) && !string.IsNullOrEmpty(ns)) {
          prefix = LookupPrefix(ns);
        }
        base.WriteStartElement(prefix, localName, ns);
      }
    }
