    public class TeamVM
    {
        public int ID { get; set; }    
        public string Name { get; set; }
        public DateTime? LastActivity { get; set; }
    
        public IList<PLayerVM> PlayerVM { get; set; }
    
        public int NumberPlayers { 
            get { return PlayerVM.Count(); }
        }
    }
