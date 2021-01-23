    public class HolyQuran
    {
        [XmlAttribute]
        public int TranslationID { get; set; }
        [XmlAttribute]
        public string Writer { get; set; }
        [XmlAttribute]
        public string Language { get; set; }
        [XmlAttribute]
        public string LangIsoCode { get; set; }
        [XmlAttribute]
        public string Direction { get; set; }
        [XmlElement("Chapter")]
        public List<Chapter> Chapters { get; set; }
    }
    
    public class Chapter
    {
        [XmlAttribute]
        public int ChapterID { get; set; }
        [XmlAttribute]
        public string ChapterName { get; set; }
        [XmlElement("Verse")]
        public List<Verse> Verses { get; set; }
    }
    
    public class Verse
    {
        [XmlAttribute]
        public int VerseId { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
