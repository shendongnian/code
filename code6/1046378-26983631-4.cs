    static void Main(string[] args)
    {
        ImageProperties props = new ImageProperties();
        props.ImageName = "img.png";
        props.ImageFilePath = "c:\\temp\\img.png";
        props.Filters = new List<IFilter>();
        props.Filters.Add(new MyFilter() { SomeMyFilterProp = "x", SomeCommonProp ="p" });
        props.Filters.Add(new MyOtherFilter() { SomeOtherFilterProp = "y", SomeCommonProp ="p" });
            
        XmlSerializer s = new XmlSerializer(typeof(ImageProperties));
        using (StreamWriter writer = new StreamWriter(@"c:\temp\imgprops.xml"))
            s.Serialize(writer, props);
        using (StreamReader reader = new StreamReader(@"c:\temp\imgprops.xml"))
        {
            object andBack = s.Deserialize(reader);
        }
        Console.ReadKey();
    }
