    public interface IMyDbContext {
        //Only expose people, not orders for example
        DbSet<Person> People { get; set; }
    }
    public partial class MyDbContext : IMyDbContext {
        //the generated DbContext class satisfies the interface
    }
    public class PersonService {
        private readonly IMyDbContext _context;
        public PersonService(IMyDbContext context){
            _context = context;
        }
    }
