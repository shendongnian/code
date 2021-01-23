    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack) {
        SqlConnection con = new SqlConnection("connection string");
        con.Open();
        DataTable Seminars = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT SeminarName, ID  FROM SeminarData", con);
        adapter.Fill(Seminars);
        DropDownList1.DataSource = Seminars;
        DropDownList1.DataTextField = "SeminarName";
        DropDownList1.DataValueField = "SeminarName";
        DropDownList1.DataBind(); 
        con.Close();
      }
    }
