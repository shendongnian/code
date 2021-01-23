     public class Application
    {
    public int ApplicationId { get; set; }
    [Required]
    [DisplayName("First Name")]
    public string FirstName { get; set; }
    [DisplayName("Last Name")]
    public string LastName { get; set; }
    [ForeignKey("aspnetusers")] 
    [Column("Id")]
    public int ApplicationUserId { get; set; }
    ....
