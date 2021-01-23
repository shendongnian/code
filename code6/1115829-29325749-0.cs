    [XmlRoot("ManifestHeader", Namespace = ManifestHeader.XmlNamespace)]
    public class ManifestHeader : IXmlSerializable
    {
        public const string XmlNamespace = "MyNamespace";
        public static XmlSerializerNamespaces GetXmlSerializerNamespaces()
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", ManifestHeader.XmlNamespace);
            return ns;
        }
        // Some example properties
        public string AProperty { get; set; }
        public string ZProperty { get; set; }
        // The list of parties.
        public AParty[] Parties { get; set; }
        #region IXmlSerializable Members
        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            var ns = GetXmlSerializerNamespaces();
            writer.WriteElementString("ZProperty", ZProperty);
            foreach (var value in Parties)
            {
                XmlSerializationHelper.SerializeElementTo(value, "Party", ManifestHeader.XmlNamespace, writer, ns);
            }
            writer.WriteElementString("AProperty", AProperty);
        }
        #endregion
    }
    public abstract class AParty
    {
        [XmlAttribute]
        public abstract string Role { get; set; } // Returns a constant string; setter does nothing.
    }
