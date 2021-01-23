    public struct State
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlText]
        public string Value { get; set; }
        public override string ToString()
        {
            return string.Format("Name={0}, Value=\"{1}\"", Name, Value);
        }
    }
    [XmlRoot("user")]
    public class User
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("date")]
        public DateTime Date { get; set; }
        [XmlElement("state")]
        public List<State> State { get; set; }
    }
