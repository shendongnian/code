    [XmlRoot("Tools")]
    public class ToolList
    {
        public ToolList() { Items = new List<Tool>(); }
        [XmlElement("Tool")]
        public List<Tool> Items;
    }
    private void ToolHandling_Loaded(object sender, RoutedEventArgs e)
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(ToolList));
        using (var reader = new StreamReader(@Start.userConfigurePath + 
        "\\config.xml"))
        {
        toolList = (ToolList)deserializer.Deserialize(reader);
        reader.Close();
        }
    }
