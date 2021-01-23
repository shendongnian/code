    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadMyRepeater();
        }
    
    }
    private void LoadMyRepeater()
    {
    
        string filename = this.Parent.Page.Title;
        Label parLbl = (Label)Parent.FindControl("Label1");
        if (parLbl != null)
        {
            Labelpart.Text = parLbl.Text;
        }
        string b = Labelpart.Text;
        string part = b;
        string fam = b.Substring(0, 2);
        Labelfam.Text = fam;
        string act = b.Substring(4, 2);
        Labelact.Text = act;
        string switches = b.Substring(2, 2);
        Labelswitch.Text = switches;
        string switch02 = "02";
        string switch03 = "03";
        string switch11 = "11";
        string switch12 = "12";
    
        string str = "SELECT [ID], [ProductName] FROM [bvc_Product] WHERE (([ProductName] LIKE '%' + @param1 + '%') AND ([ProductName] LIKE '%' + @param2 + '%') AND ([ProductName] NOT LIKE '%' + @param3 + '%') AND (([ProductName] LIKE '%' + @param4 + '%') OR ([ProductName] LIKE '%' + @param5 + '%') OR ([ProductName] LIKE '%' + @param6 + '%') OR ([ProductName] LIKE '%' + @param7 + '%') OR ([ProductName] LIKE '%' + @param8 + '%')))";
        SqlConnection con = new SqlConnection(connectionStrings); 
        SqlCommand cmd = new SqlCommand(str, con);
    
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@param1", fam);
        cmd.Parameters.AddWithValue("@param2", act);
        cmd.Parameters.AddWithValue("@param3", part);
        cmd.Parameters.AddWithValue("@param4", switches);
        cmd.Parameters.AddWithValue("@param5", switch02);
        cmd.Parameters.AddWithValue("@param6", switch03);
        cmd.Parameters.AddWithValue("@param7", switch11);
        cmd.Parameters.AddWithValue("@param8", switch12);
    
    
        con.Open();
        SqlDataReader rdr = cmd.ExecuteReader();        
        MyRepeater.DataSource = rdr;
        MyRepeater.DataBind();
        con.Close();
    }
