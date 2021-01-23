    public class TigerTrackingViewModel
    {
        public TigerTrackingViewModel(){
           this.TigerTrail = new TigerTrail(); //Add this
        }
    
        public Guid YouthGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TigerTrail TigerTrail { get; set; }
    }
