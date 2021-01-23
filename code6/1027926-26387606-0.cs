    protected void Page_Load(object sender, EventArgs e)
    {
          if(!IsPostBack)
          {
            string Query = "SELECT * FROM database;";
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(Query, conn);
    
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
           }
    }
