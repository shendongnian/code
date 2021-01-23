     public partial class YourDBContextClass
     {
        // Add a constructor to allow the connection string name to be changed
     public YourDBContextClass(string connectionStringNameInConfig)
            : base("name=" + connectionStringNameInConfig)
        {
        }
    }
