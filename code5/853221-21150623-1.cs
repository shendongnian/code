    public class PersonLastProactiveCall
    {
        [Required]
        [ForeignKey("Id")]
        public virtual Person Person { get; set; }
        public DateTime? Date { get; set; }
    }
    ...
    // On person model
    [ForeignKey("Id")]
    public virtual PersonLastProactiveCall LastProactiveCall { get; set; }
