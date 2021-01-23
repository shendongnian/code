    [XmlRoot("Books")]
    public class BookList
    {
        [XmlElement("Book")]
        public List<Book> Books { get; set; }
    }
    
    public class Book
    {
        [XmlAttribute("Title")]
        public string Title { get; set; }
    
        [XmlElement("Attribute")]
        public List<AttributePair<String, String>> Attributes { get; set; }
    }
    
    [Serializable]
    [XmlType(TypeName = "Attribute")]
    public struct AttributePair<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
    
        public AttributePair(K key, V val)
            : this()
        {
            Key = key;
            Value = val;
        }
    }
