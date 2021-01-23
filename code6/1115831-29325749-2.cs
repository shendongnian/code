    [XmlRoot("ChargeParty", Namespace = ManifestHeader.XmlNamespace)]
    [XmlType("ChargeParty", Namespace = ManifestHeader.XmlNamespace)]
    public sealed class ChargeParty : AParty
    {
        [XmlAttribute]
        public override string Role
        {
            get
            {
                return "CHARGE";
            }
            set
            {
            }
        }
        public bool IsCharging { get; set; }
    }
    [XmlRoot("SenderParty", Namespace = ManifestHeader.XmlNamespace)]
    [XmlType("SenderParty", Namespace = ManifestHeader.XmlNamespace)]
    public sealed class SenderParty : AParty
    {
        [XmlAttribute]
        public override string Role
        {
            get
            {
                return "SENDER";
            }
            set
            {
            }
        }
        public string SenderName { get; set; }
    }
    public static class TestClass
    {
        public static void Test()
        {
            var manifest = new ManifestHeader
            {
                AProperty = "A property",
                ZProperty = "Z Property",
                Parties = new AParty[] { new SenderParty { SenderName = "Sender Name" }, new ChargeParty { IsCharging = true }, new SenderParty { SenderName = "Another Sender Name" }, new SenderParty { SenderName = "Yet Another Sender Name" }, new ChargeParty { IsCharging = false } }
            };
            var xml = manifest.GetXml(ManifestHeader.GetXmlSerializerNamespaces());
            Debug.WriteLine(xml);
        }
    }
