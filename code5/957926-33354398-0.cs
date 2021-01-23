    public partial class MyDataContext : System.Data.Linq.DataContext
    {
        public MyDataContext() 
            :base( ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString, mappingSource)
        {
    
        }
    }
