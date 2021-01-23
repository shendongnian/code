    private DataTable FillRepeater()
    {
      using (SqlConnection con = new SqlConnection(ConnectionStringn))
      {
        using (SqlCommand cmd = new SqlCommand("select drivername,carname,carnumber,driverphoto from driver"))
        {
          cmd.Connection = con;
          try
          {
             DataTable dt = new DataTable();
             SqlDataAdapter dataAdapt = new SqlDataAdapter();
             dataAdapt.SelectCommand = cmd;
             dataAdapt.Fill(dt);
             return dt;
          }
          catch(Exception)
          {
            throw;
          }
      }
    }
 
    // Now fill the repeater in Page_Load() or something else
    Repeater1.DataSource = FillRepeater();
    Repeater1.DataBind();
