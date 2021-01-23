    YourObject oObject = new YourObject ();
    try
    {
       XmlSerializer oSerializer = new XmlSerializer(typeof(YourObject));
        using (StringReader oReader = new StringReader(XmlString)) 
        {
           oObject = (YourObject)oSerializer.Deserialize(oReader);
        }
    }
    catch
    {
      ...
    }
