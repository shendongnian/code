    public class Floor {
        public int DBedrooms {get; set; }
        public int DKitchens {get; set; }
        public int DLiving { get; set; } 
    }
        
    public class House {
        public List<Floor> Floors{get;set;}
        public string NSchool { get; set; }
        public int NSchoolDist { get; set; }
        public int NCrime { get; set; } 
    }
