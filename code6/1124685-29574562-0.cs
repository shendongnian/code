    public class Panel
    {
        public int ID { get; set; }
        public List<Drug> Drugs { get; set; }
    }
    public class Drug
    {
        public int ID { get; set; }
        public List<TestedDrug> TestedDrugs { get; set; }
    }
    public class TestedDrug
    {
        public int ID { get; set; }
    }
