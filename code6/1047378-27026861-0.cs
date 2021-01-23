    Lists list = new Lists(); //SharePoint Lists SOAP service
          
    //Perform request
    XmlNode result = list.GetListCollection();
           
    //Process result
    var ds = new DataSet("ListsResults");
    using (var reader = new StringReader(result.OuterXml))
    {
        ds.ReadXml(reader, XmlReadMode.Auto);
    }
    //print List Titles
    foreach (DataRow row in ds.Tables[0].Rows)
    {
         Console.WriteLine(row["Title"]);
    }
