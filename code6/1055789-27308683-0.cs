    public class Instrument
    {
        public string Name;
        public string Category;
        public Instrument()
            : this("DefaultName", "DefaultCategory")
        {
        }
        public Instrument(string name, string category)
        {
            this.Name = name;
            this.Category = category;
        }
    }
