    public class Company
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        [Key, StringLength(128)]
        public string sys_id { get; set; }
    }
    public class Ticket
    {
        public int id { get; set; }
        public string short_desc { get; set; }
        public string company_id { get; set; }
        [ForeignKey("company_id"), StringLength(128)]
        public virtual Company Company { get; set; }
    }
