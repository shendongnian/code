     protected void Page_Load(object sender, EventArgs e)
     {
         if (!PostBack)
         {
              string DatabaseConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["proekt"].ConnectionString;
              string sql = "SELECT id,title,image,text FROM home WHERE id in (1,2,3) order by id";    
              using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
              {
              conn.Open();
