	[System.Xml.Serialization.XmlTypeAttribute (Namespace = "http://sdb.amazonaws.com/doc/2009-04-15/")]
	[System.Xml.Serialization.XmlRootAttribute ("ListDomainsResponse", Namespace = "http://sdb.amazonaws.com/doc/2009-04-15/")]
	public class ListDomainsResponse  : Response
	{
		public ListDomainsResult ListDomainsResult { get; set; }
	}
	[System.Xml.Serialization.XmlTypeAttribute (Namespace = "http://sdb.amazonaws.com/doc/2009-04-15/")]
	[System.Xml.Serialization.XmlRootAttribute (Namespace = "http://sdb.amazonaws.com/doc/2009-04-15/")]
	public class ListDomainsResult
	{
		[System.Xml.Serialization.XmlElementAttribute ("DomainName")]
		public string[] DomainName { get; set; }
		public string NextToken { get; set; }
	}
