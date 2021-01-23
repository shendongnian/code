    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStringDb1"].ToString()))
            {
                try
                {
                    String cmdText = "SELECT * FROM Image WHERE IsDeleted=@isDeleted";
                    SqlCommand cmd = new SqlCommand(cmdText, cn);
                    cmd.Parameters.AddWithValue("@IsDeleted", "false");
                    cn.Open();
                    SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
                    DataTable dt_Category = new DataTable();
                    myAdapter.Fill(dt_Category);
                    cn.Close();
    
                    gv.DataSource = dt_Category;
                    gv.DataBind();
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in gv.Rows)
        {
            RadioButton rd = (RadioButton)gvr.FindControl("rd");
            if (rd.Checked)
            {
            }
            else
            {
            }
        }
    }
