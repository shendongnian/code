    //Get all the bugs.
    XmlNodeList Update_Bugs = XDoc.GetElementsByTagName("Bugs");
    //Loop through the bugs
    foreach(XmlNode updateBug in Update_Bugs)
    {
        //Check for the test condition
        if (updateBug.Attributes["TestCondition"] != null)
        {
            //Get the value of TestCondition.
            string value = updateBug.Attributes["TestCondition"].Value;
            string attributelowercase = value.ToLower();
            Console.WriteLine(attributelowercase);
            //Get the children of the node. This will be the <Bug> nodes.
            XmlNodeList newValue = updateBug.ChildNodes;
            //Get the xml string of the bugs
            string xmlString = updateBug.InnerXml;
            Console.WriteLine(xmlString);
        }
    }
