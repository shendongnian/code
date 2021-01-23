	using System;
	using System.Linq;
	using System.Xml.Linq;
	using System.Xml.XPath;					
	using System.IO;
	public class Program
	{
		public static void Main()
		{
            //XElement xml = XElement.Load(xmlFile); //Load from file
			XElement xml=XElement.Parse(@"<Attributes>  <Attribute>    <EntryID>0</EntryID>    <ContractID>227860</ContractID>    <FieldID>10882</FieldID>    <GroupID>0</GroupID>    <InstanceID>0</InstanceID>    <Value>C:\Users\laitkor\Downloads\BulkTest826.mp4</Value>    <CreatedBy>615</CreatedBy>    <CreatedOn>12/1/2014 6:51:04 AM</CreatedOn>    <UpdatedBy>615</UpdatedBy>    <UpdatedOn>12/1/2014 6:51:04 AM</UpdatedOn>  </Attribute></Attributes>");
			var valueElements = xml.XPathSelectElements("//Attribute/Value");
			
			foreach(XElement valueElement in valueElements)
			{			
				valueElement.Value=Path.GetFileName(valueElement.Value);
				Console.WriteLine(valueElement.Value);
			}
		}
	}
