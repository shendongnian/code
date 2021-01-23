    protected void Page_Load(object sender, EventArgs e)
    {
       if (!Page.IsPostBack)
       {
        using (SqlConnection connection = new SqlConnection("Data Source=PCM13812;Initial Catalog=Newsletter;Integrated Security=True"))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("Select Email From Newsletter", connection);
            EmailList.DataSource = cmd.ExecuteReader();
            EmailList.DataTextField = "Email";
            EmailList.DataBind();
        }
       }
    }
