    vehicleObject yourWorkingObject;
    
    using (MemoryStream ms = new MemoryStream(File.ReadAllBytes("c:\\a.xml")))
    {
        XmlSerializer serializer = new XmlSerializer(typeof(vehicleObject));
        yourWorkingObject = serializer.Deserialize(ms) as vehicleObject;
    }
    
    //Do with yourWorkingObject here what you want
