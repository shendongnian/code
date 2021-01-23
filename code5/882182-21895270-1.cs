    public class MatchHistory
    {
        public string MatchID { get; set; }
    
        //public List<DotaHero> Players { get; set; }
    
        public List<MyDotaClass.DotaHero> Players2 { get; private set; }
        public MatchHistory() {
            this.Players2 = new List<MyDotaClass.DotaHero>();
        }
    }
