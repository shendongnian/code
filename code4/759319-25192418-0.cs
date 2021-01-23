    public partial class MyDbEntities : DbContext 
    {
        public MyDbEntities (string ConnectionString)
            : base(ConnectionString)
        {
            this.SetCommandTimeOut(360);
        }
        public void SetCommandTimeOut(int Timeout)
        {
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = Timeout;
        }
    }
