    private void bindCourses()
    {
        var dataTable = new DataTable();
       using (var sqlConnection = new SqlConnection("Data Source=localhost;Initial Catalog=tafe_work;Integrated Security=True"))
    {
        sqlConnection.Open();
        using (var sqlCommand = new SqlCommand("select * from Course", sqlConnection))
        {
            using (var sqlReader = sqlCommand.ExecuteReader())
            {
                dataTable.Load(sqlReader);
                grdCourses.DataSource = dataTable;
                grdCourses.DataBind();
            }
        }
      }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       if(!isPostBack)
       {
           bindCourses();
       }
    }
