    using System;
    using System.Xml;
    					
    public class Program
    {
    	
    	static string xmlFile = @"<?xml version=""1.0"" encoding=""UTF-8""?>
    		<job>
    		<type>freelance</type>
    		<text>blah</text>
    		</job>";
    	
    	public static void Main()
    	{
    		var doc = new XmlDocument();
    		doc.LoadXml(xmlFile);
    		
    		XmlNode xmltype = doc.DocumentElement.SelectSingleNode("/job/type");
            if(xmltype==null)
            {
               Console.WriteLine("/job/type not found");
            } else {
    		   Console.WriteLine(xmltype.InnerText);
            }
    	}
    }
