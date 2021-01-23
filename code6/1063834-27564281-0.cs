    public class MyDbContext : DbContext 
    {
        private DbSet<Data> DataTable { get { return this.Set<Data>(); } }
        private static object lockObject = new object();
        public Data GetDataToProcess() 
        { 
           lock (lockObject) 
           {
              Data data = this.DataTable.FirstOrDefault(d => d.Processing == false);
              data.Processing = true;
              this.SaveChanges();
              return data;
           }
        }
     }
