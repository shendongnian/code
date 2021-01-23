    void Main()
    {
    	Console.WriteLine(Xmlload("Destroy 1 spell/trap on the field"));
    }
    
    public static string Xmlload(String textUserInputs)
    {
       using (var script = new XmlTextReader("Scripts.xml"))
       {
    		while (script.Read())
    		{
    			if (script.NodeType == XmlNodeType.Element &&
    				script.LocalName == "Desc" &&
    				script.IsStartElement() == true)
    			{
    					var desc = script.ReadElementContentAsString();
    					
    					if (desc == textUserInputs)
    					{
    						script.ReadToNextSibling("code");
    						
    						return script.ReadElementContentAsString();
    					}
    			}
    		}
       }
    	
       return null;
    }
