    public class SectionDto
    {
        [XmlAttribute]
        public int Id { get; set; }
        public List<SubSection> SubSections { get; set; }
    }
    [XmlInclude(typeof(DepartmentDto))]
    [XmlInclude(typeof(DivisionDto))]
    public abstract class SubSection
    {
        [XmlAttribute]
        public int Id { get; set; }
    }
    public class DepartmentDto : SubSection
    {
        [XmlElement]
        public string Summary { get; set; }
    }
    public class DivisionDto : SubSection
    {
        [XmlElement]
        public string Name { get; set; }
    }
