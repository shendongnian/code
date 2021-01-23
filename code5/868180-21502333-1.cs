    foreach (XmlNode ans in yesreplytocommand
    	.Cast<XmlNode>()
    	.OrderBy(elem => Guid.NewGuid()))
    		{
    			var attribute = ans.Attributes["expression"];
    			if (attribute != null && attribute.Value == "true")
    			{
    				Console.WriteLine(Evaluate(ans.InnerText));
    			}
    			else
    			{
    				Console.WriteLine(ans.InnerText);
    			}
    		}
