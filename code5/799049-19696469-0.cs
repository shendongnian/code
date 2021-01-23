                XElement xElement = XElement.Load(@"C:\target.xml");
    			string ns = xElement.Name.Namespace.NamespaceName;
    
    			xElement.Descendants(XName.Get("ClCompile", ns)).ToList().ForEach(x =>
    			{
    				XAttribute xAttr =  x.Attribute(XName.Get("Include"));
    
    				if (xAttr != null)
    				{
    					string name = xAttr.Value;
    					xAttr.Value = name + "?modified";
    				}
    					
    			});
    
    
    			xElement.Descendants(XName.Get("ClInclude", ns)).ToList().ForEach(x =>
    			{
    				XAttribute xAttr = x.Attribute(XName.Get("Include"));
    
    				if (xAttr != null)
    				{
    					string name = xAttr.Value;
    					xAttr.Value = name + "?included";
    				}
    			});
    
    			xElement.Save(@"C:\result.xml");
