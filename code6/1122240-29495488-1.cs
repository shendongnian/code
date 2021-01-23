    XDocument doc = XDocument.Parse("Your XML");
    string keyword = Console.ReadLine();
    
    //Navigate through all IsiNode
    foreach (var isiElement in doc.Root.Elements())
    {
    	if (isiElement.Value.Contains(keyword))
    	{
    		Console.WriteLine (isiElement.Value);
    	}
    }
