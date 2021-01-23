    public class Word
    {
        [XmlAttribute("lex_id")]
        public string LexId { get; set; }
        [XmlText]
        public string Value { get; set; }
        public override string ToString()
        {
            return Value;
        }
        public static explicit operator string(Word word)
        {
            if (word == null)
                return null;
            return word.Value;
        }
    }
    public class SynsetPointer
    {
        [XmlAttribute("refs")]
        public string Refs { get; set; }
        [XmlAttribute("source")]
        public string Source { get; set; }
        [XmlAttribute("target")]
        public string Target { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
    [XmlRoot("synset")]
    [XmlType("synset")]
    public class Synset
    {
        public Synset()
        {
            this.Pointers = new List<SynsetPointer>();
            this.Words = new List<Word>();
        }
        [XmlElement("lex_filenum")]
        public int LexFilenum { get; set; }
        [XmlElement("word")]
        public List<Word> Words { get; set; }
        [XmlIgnore]
        public IEnumerable<string> WordValues { get { return (Words == null ? null : Words.Select(w => (string)w)); } }
        [XmlElement("pointer")]
        public List<SynsetPointer> Pointers { get; set; }
        [XmlElement("def")]
        public string Definition { get; set; }
    }
    [XmlRoot("DictionaryList")]
    public class DictionaryList
    {
        public DictionaryList()
        {
            this.Dict = new List<Synset>();
        }
        [XmlArray("synsets")]
        [XmlArrayItem("synset")]
        public List<Synset> Dict { get; set; }
        //string filepath = Application.dataPath + "/Resources/gamedata.xml";
        public static DictionaryList Load(string path)
        {
            var serializer = new XmlSerializer(typeof(DictionaryList));
            using (var stream = new FileStream(path, FileMode.Open))
            {
                return serializer.Deserialize(stream) as DictionaryList;
            }
        }
        //Loads the xml directly from the given string. Useful in combination with www.text.
        public static DictionaryList LoadFromText(string text)
        {
            var serializer = new XmlSerializer(typeof(DictionaryList));
            return serializer.Deserialize(new StringReader(text)) as DictionaryList;
        }
    }
