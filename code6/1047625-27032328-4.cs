    public class Cell
    {
        [XmlText]
        public string Text { get; set; }
        [XmlAttribute("INDEX")]
        public int Index { get; set; }
    }
    [XmlRoot("ROW")]
    public class Row
    {
        [XmlElement("CELL")]
        public List<Cell> Cells { get; set; }
    }
