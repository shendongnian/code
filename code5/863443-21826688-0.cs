    public class LocalContext : DbContext
    {
        protected override void Dispose(bool disposing)
        {
            var connection = this.Database.Connection;
            base.Dispose(disposing);
            connection.Dispose();
        }
    }
