    [DelimitedRecord(";")]
    [IgnoreFirst(1)] 
    public class RootObject
    {
        public string Amount { get; set; }
        public string P_price { get; set; }
        public object Ean { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public int DPH { get; set; }
        public int certifikate { get; set; }
        public int o1 { get; set; }
        public int o2 { get; set; }
        public int ZC { get; set; }
    }
    FileHelperEngine<Orders> engine = new FileHelperEngine<RootObject>(); 
    // to Read use: 
    Orders[] res = engine.ReadFile("TestIn.txt"); 
