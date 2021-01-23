    public class Panel
    {
        public int ID { get; set; }
        public List<DrugClass> DrugClasses { get; set; }
    }
    public class DrugClass
    {
        public int ID { get; set; }
        public List<TestedDrug> TestedDrugs { get; set; }
    }
    public class TestedDrug
    {
        public int ID { get; set; }
    }
