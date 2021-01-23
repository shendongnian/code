    var boilingModelObj = new BoilingModel();
    // ... fill object with data ...
    var serializer = new XmlSerializer(typeof(BoilingModel));
    using(var writer = new StreamWriter("boilingmodel.xml"))
    {
        serializer.Serialize(writer, boilingModelObj);
    }
