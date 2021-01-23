    public class Chapter
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public List<Verse> Verses { get; set;}
    }
    public class Verse
    {
        public int Id { get; set; }
        public string Contents { get; set; }
        public static Verse FromXElement(XElement element)
        {
            return new Verse { Id = (int)element.Attribute("VerseID"), 
                Contents = element.Value };
        }
    }
