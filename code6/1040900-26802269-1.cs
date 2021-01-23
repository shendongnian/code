    var xml  = @"<Student number='2020'>
                              <Subject>Comp</Subject>
                              <Credintials>
                                <Password>010101</Password>
                                <PasswordLength>6</PasswordLength>
                                <Contact>contact@example.com</Contact>
                              </Credintials>
                              <PersonalDetails age='30' height='2'/>
                              <Lecture age='30' height='2'>
                                <StudentName>Hakeem</StudentName>
                              </Lecture>
                            </Student>";
    var xmlParsed = XElement.Parse(xml);
    GetNodeDescendantsAndPrint(xmlParsed);
    public void GetNodeDescendantsAndPrint(XElement node, string nameToAppend= null)
	{
		var name = string.IsNullOrEmpty(nameToAppend) 
							? node.Name.LocalName  
							: nameToAppend;
		foreach (var att in node.Attributes())
		{
			Console.WriteLine(name + ".@" + att.Name.LocalName + "=" + att.Value);
		}
		var descendants = node.Elements();
		if (descendants.Any())
		{
			foreach (var innerNode in descendants.OfType<XElement>())
			{
				GetNodeDescendantsAndPrint(innerNode, 
											name+"." + innerNode.Name.LocalName );
			}
		}
		else
		{
				Console.WriteLine(name + "=" + node.Value);
		}
	
	}
