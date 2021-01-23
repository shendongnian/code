    public partial class ProducerCentralEntities : DbContext
        {
            public ProducerCentralEntities()
          : base(@"metadata = res://*/TestProj.csdl|res://*/TestProj.ssdl|res://*/TestProj.msl;provider=System.Data.SqlClient;provider connection string=';data source=serverName;initial catalog=databaseName;integrated security=True;MultipleActiveResultSets=True;application name=EntityFramework';")
            {
            }
          }
        
