    protected void Page_Load(object sender, EventArgs e)
        {
    
            if (!Page.IsPostBack)
            {
                string QUEST_SK = Request.QueryString["QUEST_SK"].ToString();
                // string MPost_ID = "773";
                sqlcon.Open();
                sqlcmd = new SqlCommand("SELECT ID, DESC  FROM Table1 WHERE ID= " + ID, sqlcon);
                da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
                sqlcon.Close();
                GridView1.DataSource = dt;
                GridView1.DataBind();
                sqlcon.Close();
            }
        }
