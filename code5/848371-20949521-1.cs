    internal void alterXml(string param, bool replace = false, string value = null)
    {
    	//load xml configuration file to XDocument object
    	var doc = XDocument.Load(path);
    	//search for <param> having attribute "name" = param
    	var existingParam = doc.Descendants("param").FirstOrDefault(o => o.Attribute("name").Value == param);
    	//if such a param element doesn't exist, add new element
    	if (existingParam == null)
    	{
    		var newParam = new XElement("param");
    		newParam.SetAttributeValue("name", param);
    		newParam.Value = "" + value;
    		doc.Root.Add(newParam);
    	}
    	//else update element's value
    	else if (replace) existingParam.Value = "" + value;
    	//save modified object back to xml file
    	doc.Save(path);
    }
