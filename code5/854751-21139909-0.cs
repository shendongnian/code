    public class Choice
    {
        public int Id { get; set; }
        [ForeignKey("Event")]
        public int EventID { get; set; }
        public virtual Event Event { get; set; }
        public virtual Wine Wine { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Guess { get; set; }
        public string Comment { get; set; }
    }
