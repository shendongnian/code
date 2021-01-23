    XElement root = XElement.Load(@"path\to\xml");
    XmlSerializer serializer = new XmlSerializer(typeof(InputData));
    InputData inData;    	
	
	root.Elements("Processes")
		.Elements("Student")
		.Where (r => r.Element("Group") == null && r.Element("Priority") == null)
		.ToList()
		.ForEach(x => {
			Random r = new Random();
			x.Add(new XElement("Group", r.Next(1,10)));
			x.Add(new XElement("Priority", r.Next(1,10)));
		});
						
	using (StringReader reader = new StringReader(root.ToString())) 
	{
        inData = (InputData)(serializer.Deserialize(reader));
    }
