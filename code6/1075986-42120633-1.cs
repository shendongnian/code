    public class HangfireContext : DbContext
    {
        public HangfireContext() : base("HangfireContext")  // Remove "name="
        {
            Database.SetInitializer<HangfireContext>(null);
            Database.CreateIfNotExists();
        }
    }
    public partial class Startup
    {
        public static void ConfigureHangfire(IAppBuilder app)
        {
            var db = new HangfireContext();
            GlobalConfiguration.Configuration.UseSqlServerStorage(db.Database.Connection.ConnectionString);  // Copy connection string
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
