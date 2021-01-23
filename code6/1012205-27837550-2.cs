        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TelerikConnectionString"].ConnectionString.ToString());
        conn.Open();
        SqlDataAdapter adapter;
        DataTable dt = new DataTable();
        adapter = new SqlDataAdapter("SELECT * FROM GanttTasks", conn);
        adapter.Fill(dt);
        SqlDataSource2.ConnectionString = ConfigurationManager.ConnectionStrings["TelerikConnectionString"].ConnectionString.ToString();
        SqlDataSource2.SelectCommand = "SELECT * FROM GanttTasks";
        SqlDataSource2.DataBind();
        SqlDataSource4.ConnectionString = ConfigurationManager.ConnectionStrings["TelerikConnectionString"].ConnectionString.ToString();
        SqlDataSource4.SelectCommand = "SELECT * FROM GanttDependencies";
        SqlDataSource4.UpdateCommand = "UPDATE GanttDependencies SET PredecessorID = @PredecessorID, SuccessorID = @SuccessorID, Type = @Type WHERE ID = @ID";
        SqlDataSource4.DataBind();
       
        RadGantt1.DataSourceID = SqlDataSource2.ID;
        RadGantt1.DependenciesDataSourceID = SqlDataSource4.ID;
     
        conn.Close();
