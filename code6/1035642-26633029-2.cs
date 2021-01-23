    using System.Xml.Serialization;
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Codes
    {
      [XmlElementAttribute("CustomFieldValueSet")]
      public List<CodesCustomFieldValueSet> CustomFieldValueSet { get; set; }
    }
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class CodesCustomFieldValueSet
    {
      [XmlElementAttribute("CustomFieldValue")]
      public List<CodesCustomFieldValueSetCustomFieldValue> CustomFieldValue { get; set; }
      [XmlAttributeAttribute(AttributeName="name")]
      public string Name { get; set; }
      [XmlAttributeAttribute(AttributeName = "label")]
      public string Label { get; set; }
      [XmlAttributeAttribute(AttributeName = "distributionType")]
      public string DistributionType { get; set; }
    }
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class CodesCustomFieldValueSetCustomFieldValue
    {
      public string Value { get; set; }
      public string Description { get; set; }
      [XmlAttributeAttribute(AttributeName = "distributionValue")]
      public decimal DistributionValue { get; set; }
      [XmlAttributeAttribute(AttributeName = "splitindex")]
      public byte SplitIndex { get; set; }
    }
