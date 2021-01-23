    Dictionary <string, string> foo=new Dictionary<string,string>();
    Dictionary <string, string> blah;
    
    XElement xelement = XElement.Load("D:\\x.xml");
    IEnumerable<XElement> sections = xelement.Elements();
    	 foreach (var section in sections)
    	 {
    		  switch (section.Attribute("name").Value)
    		  {
    			  case "foo":
    				    foreach (XElement element in section.Descendants().Where(p => p.HasElements == false))
    		{
    			int keyInt = 0;
    			string keyName = element.Attribute("name").Value;
    
    			while (foo.ContainsKey(keyName))
    				keyName = element.Attribute("name") + "_" + keyInt++;
    
    			foo.Add(keyName, element.Value);
    		}
    		foo.Dump();
    				   
    				   break;
    
    			  case "blah":
    				   
    				   break;
    		  }
    	 }
