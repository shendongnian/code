    public class ContextName : DbContext {
        // Tables
        public DbSet<SomeTableClassHere> ATable { get; set; }
        // And other tables...
        // Views
        public DbSet<ViewClassName> ViewContextName { get; set; }
        
        // This lines help me during "update-database" command
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            // Remove comments before "update-database" command and 
            // comment this line again after "update-database", otherwise 
            // you will not be able to query the view from the context.
            // Ignore the creation of a table named "view_name_on_database"
            modelBuilder.Ignore<ViewClassName>();
        }
    }
