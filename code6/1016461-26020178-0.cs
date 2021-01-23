    class Occupation {
        [Key]
        public int OccupationID{get;set;}
        public string OccupationName{get;set}
        
        [NotMapped]
        public Address Location{get;set;}
        public int PersonID{get;set;}
        public virtual Person Person{get;set;}
    }
