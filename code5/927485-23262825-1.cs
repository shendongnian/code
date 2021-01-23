        protected void Page_Load(object sender, EventArgs e)
        {
        
            if (!this.Page.IsPostBack)
            {
                //Panel1.Visible = false; Comment
                PopulateCategory();
                getSubCategories(CategoryDropDownList.SelectedValue);
                //CategoryDropDownList_SelectedIndexChanged(null, null);
            }
        }
    
    
    protected void txtUniqueNo_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtUniqueNo.Text))
        {
            OdbcConnection conn = new OdbcConnection(DB.DatabaseConnString());
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            OdbcCommand cmd = new OdbcCommand("select * from gallery where unique_no='" + txtUniqueNo.Text + "'", conn);
    
            OdbcDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                checkusername.Visible = true;
               Panel1.Style.Add("display", "none");
                imgstatus.ImageUrl = "~/images/unavailable.png";
                lblStatus.Text = "Unique Id Already Taken";
    
            }
            else
            {
                try
                {
                    checkusername.Visible = true;
                    Panel1.Style.Add("display", "block");
                    imgstatus.ImageUrl = "~/images/tick.png";
                    lblStatus.Text = "Unique Id  Available";
                }
                catch (Exception ex)
                {
                    string mess = ex.Message;
                }
    
            }
        }
        else
        {
            checkusername.Visible = false;
        }
    }
