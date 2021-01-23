    public class Office {
        public long Identifier { get; set; }
        public string Address { get; set; }
        public long EmployesCount { get; set; }
    
        public Rooms Rooms { get; set; }
    
        public Office() {
          this.Rooms = new Rooms();
        }
    }
