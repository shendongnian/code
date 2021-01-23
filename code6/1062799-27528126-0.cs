    public class JobOffer {
         [Key]
         public int Id { get; set; }
         public string Client { get; set; }
         public virtual ICollection<Language> Languages { get; set; }
    }
    public class Language {
         [Key]
         public int Id { get; set; }
         public string Name { get; set; }
         public virtual ICollection<JobOffer> JobOffers { get; set; }
    }
