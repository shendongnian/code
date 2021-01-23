    public class Email
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Id { get; set; }
       [Index("IX_EmailUniqueness", 1, IsUnique = true)]
       public string Subject { get; set; }
       public string Body { get; set; }
       [Index("IX_EmailUniqueness", 2, IsUnique = true)]
       public string From { get; set; }
       [Index("IX_EmailUniqueness", 3, IsUnique = true)]
       public DateTime SentOn { get; set; }
       public List<string> To { get; set; }
    }
