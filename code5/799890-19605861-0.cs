    class Program
    {
    	static void Main(string[] args)
    	{
    		if (args.Length != 3)
    		{
    			Console.WriteLine("You have not entered the correct parameters");
    			return;
    		}
    		string xmlfile = args[0];
    		string xslfile = args[1];
    		string outfile = args[2];
    		try
    		{
    			XPathDocument doc = new XPathDocument(xmlfile);
    			XslCompiledTransform transform = new XslCompiledTransform();
    			transform.Load(xslfile);
    			XmlWriter writer = XmlWriter.Create(outfile, transform.OutputSettings);
    			transform.Transform(doc, writer);
    			writer.Close();
    		}
    		catch (Exception e)
    		{
    			Console.WriteLine(e.StackTrace);
    		}
    	}
    }    
