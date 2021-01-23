    namespace XML_Reader
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			XmlDocument xdoc = new XmlDocument();
    			xdoc.Load("test.xml");
    			XmlNode elem = xdoc.DocumentElement.FirstChild;
    
    			Console.WriteLine(elem.InnerXml);		
    		}
    	}
    }
