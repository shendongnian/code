         protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
    if(ddlGroup.Text!="--Select--")
    {
                SqlConnection conn = new SqlConnection(strcon);
                conn.Open();
                string strQuery = "select distinct(Code) from Application where Date = '" + ddlDate.Text + "' and Group='" + ddlGroup.Text + "'";
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ddlCode.DataSource = dt;
                ddlCode.DataTextField = "Code";
                ddlCode.DataBind();
                ddlCode.Items.Insert(0, new ListItem("--Select--", "0"));
                conn.Close();
                DataTable dtGroup = DataRepository.GetGroup(ddlDate.Text, ddlGroup.Text);
                gvDetails.DataSource = dtGroup;
                gvDetails.DataBind();
    }
    
    else
    {
    // call ddlDate_SelectedIndexChanged 
    }                                  
        }
