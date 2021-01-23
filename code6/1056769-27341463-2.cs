    public class US_State
    {
        public string Name { get; set; }
        public string Abbreviations { get; set; }
        public US_State(string abbreviations, string name)
        {
            Abbreviations = abbreviations;
            Name = name;
        }
    }
