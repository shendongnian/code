    var obj = JsonConvert.DeserializeObject<RootClass>(json);
****
    public class RootClass
    {
        public Dictionary<string,double> banpercent { get; set; }
        public Dictionary<string, double> banpercentchosen { get; set; }
        public Dictionary<string, double> winpicks { get; set; }
        public int games { get; set; }
        public Dictionary<string, double> pickpercentchosen { get; set; }
        public Dictionary<string, double> losspicks { get; set; }
        public Dictionary<string, double> pickpercent { get; set; }
        public Dictionary<string, double> banpicks { get; set; }
        public Dictionary<string, double> winpercent { get; set; }
        public Dictionary<string, double> totpicks { get; set; }
    }
