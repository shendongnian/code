    public class SchoolContext : DbContext
    {
        //static LoggerFactory object
        public static readonly ILoggerFactory loggerFactory = new LoggerFactory(new[] {
                  new ConsoleLoggerProvider((_, __) => true, true)
            });
    
        //or
        // public static readonly ILoggerFactory loggerFactory  = new LoggerFactory().AddConsole((_,___) => true);
        
        public SchoolContext():base()
        {
    
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory)  //tie-up DbContext with LoggerFactory object
                .EnableSensitiveDataLogging()  
                .UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
        }
            
        public DbSet<Student> Students { get; set; }
    }
