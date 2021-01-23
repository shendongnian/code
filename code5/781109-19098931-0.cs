    public class Goal
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        // Read only field not mapped
        public Date CustomDate { get { return this.Date; }}
        // OR... specificallly ignored property that enables setting via custom type
        [NotMapped] // In System.ComponentModel.DataAnnotations.Schema namespace
        public Date CustomDate { 
                                    get { 
                                         return this.Date; 
                                    }
                                    set {
                                        this.Date = value;
                                    }
                               }        
    }
