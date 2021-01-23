    List<string> output = new List<string>();
    foreach(XmlNode name in xDoc.SelectNodes("Web_Service/Food/Name"))
    {
    	output.Add(name.InnerText);
    }
    TextBox2.Text = string.Join(", ", output);
