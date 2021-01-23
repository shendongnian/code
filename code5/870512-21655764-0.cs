    public class Company {
        public string Name { get; set; }
    }
    public class Store : Company {
        public string Country { get; set; }
        public Dictionary<String, Double> Salaries { get; set; }
    }
