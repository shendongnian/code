    public class Receptor
    {
        public Receptor(string name)
        {
            this.Name = name;
            this.Codes = new List<string>();
        }
        public string Name { get; set; }
        public List<string> Codes { get; set; }
    }
