    protected void BindVin(string state)
    {
    	Repeater rpt = null;
    	Control ctl = null;
    	string name = string.Empty;
    	SqlConnection conn = null;
    	SqlCommand cmd = null;
    
    	name = "Repeater_" + state;
    	ctl = Page.FindControl(name);
    	rpt = ctl as Repeater;
    	if (rpt != null) {
    		try {
    			conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings("DBConnection"));
    			cmd = new SqlCommand();
    			cmd.CommandType = CommandType.StoredProcedure;
    			cmd.CommandText = "GetAllVinNumbers"; // should this have the state to get VINs for?
    			cmd.Connection = conn;
    
    			cmd.Parameters.Add("@POLICY", SqlDbType.VarChar);
    			cmd.Parameters("@POLICY").Value = ddlPolicy.SelectedValue;
    			cmd.Parameters.Add("@VIN", SqlDbType.VarChar);
    			cmd.Parameters("@VIN").Value = dr("VIN").ToString();
    
    			if (conn.State != ConnectionState.Open) {
    				conn.Open();
    			}
    
    			rpt.DataSource = cmd.ExecuteReader();
    			rpt.DataBind();
    			rpt.Visible = true;
    
    			conn.Close();
    			conn.Dispose();
    		} catch (Exception ex) {
    			lblMessage.Text = ex.Message;
    			lblMessage.Visible = true;
    		} finally {
    			conn.Close();
    			conn.Dispose();
    		}
    	}
    }
    
    protected void GetVinData()
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DBConnection"]);
        SqlCommand cmmd = new SqlCommand();
        cmmd.CommandType = CommandType.StoredProcedure;
        cmmd.CommandText = c
        cmmd.Connection = cn;
        cn.Open();
    
        try
        {
            cmmd.Parameters.Add("@POLICY", SqlDbType.VarChar);
            cmmd.Parameters["@POLICY"].Value = ddlPolicy.SelectedValue;
            cmmd.Parameters.Add("@VIN", SqlDbType.VarChar);
            cmmd.Parameters["@VIN"].Value = txtMsg.Value;
    
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmmd);
            adapter.Fill(dt);
    
            foreach (DataRow dr in dt.Rows)
            {
                BindVin(dr["STATE"].ToString());
            }
        }
    }
