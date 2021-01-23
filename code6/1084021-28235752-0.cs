    List<YourClass> objectForValuesAndComments=new List<YourClass>();
    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load(@"C:\Location To XML\File.xml");
    foreach (XmlNode subnode in xmlDoc.DocumentElement.ChildNodes)
    {
        YourClass objectToInsert=new YourClass();
        foreacht(XmlNode SubSubNode in subnode.ChildNodes)
        {
           if (SubSubNode.Name == "value")
           {
              objectToInsert.Value = SubSubNode.InnerText;
           }
           else if (SubSubNode.Name == "comment")
           {
              objectToInsert.Comment= SubSubNode.InnerText;
           }
        }
        objectForValuesAndComments.Add(objectToInsert);
     }
