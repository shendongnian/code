    XElement current = null;
	List<XElement> elements = xDoc.Root.Descendants().ToList();
	for (int i = 0; i < xDoc.Root.Descendants().Count(); i++)
	{
		current = elements[i];
		if (condition)
		{
            // Set i to the highest available number which causes the loop stop.
			i = xDoc.Root.Descendants().Count();
		}
	}
