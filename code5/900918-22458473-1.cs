    string someXML = "<Root><Child1>Test</Child1><Child2><GrandChild></GrandChild></Child2></Root>";
    var xml = XDocument.Parse(someXML);
    Console.WriteLine ("XML:");
    Console.WriteLine (xml);
    Console.WriteLine ("\nNodes();\n");
    foreach (XNode node in xml.Descendants("Root").Nodes())
    {
	    Console.WriteLine ("Child Node:");
    	Console.WriteLine (node);
	    Console.WriteLine ("");
    }
    Console.WriteLine ("DescendantNodes();\n");
    foreach (XNode node in xml.Descendants("Root").DescendantNodes())
    {
    	Console.WriteLine ("Descendent Node:");
    	Console.WriteLine (node);
    	Console.WriteLine ("");
    }
