    List<string> addresses = new List<string>();
    XmlReader ReadFile = XmlReader.Create(AgentConfig.FileName);
    while (ReadFile.Read())
    {
    	if ((ReadFile.NodeType == XmlNodeType.Element) && (ReadFile.Name == "endpoint"))
    	{
    		if (ReadFile.HasAttributes)
    		{
    			addresses.Add(ReadFile.GetAttribute("address"));
    		}
    	}
    }
    if (addresses.Count >0)
    {
    	textBox1.Text = addresses[0];
    }
    if (addresses.Count >= 1)
    {
    	textBox2.Text = addresses[1];
    }
