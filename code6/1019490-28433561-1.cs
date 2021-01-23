	public class ContactContext : IdentityDbContext {
		public ContactContext()
			: base("ContactContext") {
		}
		public DbSet<Contact> Contacts { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
		public static ContactContext Create() {
			return new ContactContext();
		}
	}
