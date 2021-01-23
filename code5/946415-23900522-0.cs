    namespace your.protocol
    {
      public class PingQuery : Element
      {
        public const string PING_NS  = "urn:xmpp:ping";
    
        // used when creating elements to send
        public PingQuery(XmlDocument doc) : base("ping", PING_NS, doc)
        {}
    
        // used to create elements for inbound protocol
        public PingQuery(string prefix, XmlQualifiedName qname, XmlDocument doc)
            : base(prefix, qname, doc)
        {}
      }
    
      public class Factory : jabber.protocol.IPacketTypes
      {
        private static QnameType[] s_qnt = new QnameType[]
        {
          new QnameType("ping", PingQuery.PING_NS, typeof(your.protocol.PingQuery))
        };
        QnameType[] IPacketTypes.Types { get { return s_qnt; } }
      }
    }
