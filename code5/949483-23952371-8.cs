    public class MenuRoot
    {
        public List<Tricks> Category { get; set; }
    }
    public class Tricks
    {
        [XmlElementAttribute("Name")]
        public string SubTitle { get; set; }
        [XmlElementAttribute("Description")]
        public string SubTitleDescription { get; set; }
        public List<Tricks> SubItems { get; set; }
    }
