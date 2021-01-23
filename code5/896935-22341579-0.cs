    [XmlRoot("Groups")]
    public class GroupsXml
    {
        [XmlElement("Group", typeof(Group))]
        public List<Group> GroupsList { get; set; }
    }
    public class Group
    {
        [XmlAttribute("ID")]
        public int Id { get; set; }
        [XmlAttribute("Name")]
        public string Name{ get; set; }
    }
