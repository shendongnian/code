    public class Certificates
    {
        [Key]
        public int CertID { get; set; }
    
        public Users User { get; set; }
        public Quiz Quiz { get; set; }
    }
    
    public class Users
    {
        public int ID { get; set; }
        public ICollection<Certificates> Certificates { get; set; }
    }
    
    public class Quiz
    {
        public int QuizID { get; set; }
        public ICollection<Certificates> Certificates { get; set; }
    }
    
    public class cpdContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entitiy<Users>()
                .HasMany(u => u.Certificates)
                .WithRequired(c => c.User)  // or WithOptional
                .Map(m => m.MapKey("UserID")); //<- DB FK column name
    
            modelBuilder.Entitiy<Quiz>()
                .HasMany(u => u.Certificates)
                .WithRequired(c => c.Quiz)  // or WithOptional
                .Map(m => m.MapKey("QuizID")); //<- DB FK column name
        }
    }
