    public class Contract
    {
        public Contract()
        {
            Person = new Person();
        }
        public string RankName { get; set; }
        public string RankShortName { get; set; }
        public Person Person { get; set; }
    }
