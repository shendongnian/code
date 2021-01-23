    //parse the xml
    var xDoc = XDocument.Parse(html);
    
    //create our list of results (basic tuple here, could be your class)
    List<Tuple<string, string, string>> attributes = new List<Tuple<string, string, string>>();
    
    //iterate all li elemenets
    foreach (var element in xDoc.Root.Elements("li"))
    {
        //set the default values
        string time = "",
                username = "",
                message = "";
    
        //get the time, username message attributes
        XElement tElem = element.Elements("span").FirstOrDefault(x => x.Attributes("class").Count() > 0 && x.Attribute("class").Value == "time");
        XElement uElem = element.Elements("span").FirstOrDefault(x => x.Attributes("class").Count() > 0 && x.Attribute("class").Value == "username");
        XElement mElem = element.Elements("span").FirstOrDefault(x => x.Attributes("class").Count() > 0 && x.Attribute("class").Value == "message");
    
        //set our values based on element results
        if (tElem != null)
            time = tElem.Value;
    
        if (uElem != null)
            username = uElem.Value;
    
        if (mElem != null)
            message = mElem.Value;
    
        //add to our list
        attributes.Add(new Tuple<string, string, string>(time, username, message));
    }
