    class Program
    {
        public static usersDB dataBase()
        {
            return new usersDB();
        }
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<usersDB>());
            using (var db = dataBase())
            {
                var user = new User() { id = 1};
                user.a.Add(new item());
                user.a.Add(new item());
                user.a.Add(new item());
                      
                user.b.Add(new item());
                user.b.Add(new item());
                db.users.Add(user);
                
                db.SaveChanges();
            }
            using (var db = dataBase())
            {
                var user = db.users.Find(1);
                Console.WriteLine(user.a.Count); //OUT: 3
                Console.WriteLine(user.b.Count); //OUT: 2
            }
            Console.ReadLine();
        }
    }
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity )]
        public int id { get; set; }
        public virtual List<item> a { get; set; }
        public virtual List<item> b { get; set; }
        public User()
        {
            a = new List<item>();
            b = new List<item>();
        }
    }
    public class item
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        [ForeignKey("a")]
        public int? aFK { get; set; }
        [ForeignKey("b")]
        public int? bFK { get; set; }
        [InverseProperty("a")]
        public virtual User a { get; set; }
        [InverseProperty("b")]
        public virtual User b { get; set; }
    }
    public class usersDB : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<item> items { get; set; }
    }
