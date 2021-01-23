       protected void Page_Load(object sender, EventArgs e)
        {
    
            if (!IsPostBack )    
            {
    
    
                txt_rname.Enabled = false;
                txt_rmobile.Enabled = false;
                txt_remail.Enabled = false;
    
                con.Open();
                // string qry = "select * from Reporter where Reporter_ID=  " + DropDownList1.SelectedValue + "";
                lbl_1.Text = Session["id"].ToString();
                string qry = "select * from Reporter where Reporter_ID= " + Session["id"] + " ";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt); // table data-> data table
                con.Close();
                txt_rname.Text = dt.Rows[0][1].ToString();
                txt_remail.Text = dt.Rows[0][2].ToString();
                txt_rmobile.Text = dt.Rows[0][3].ToString();
    
            }
            else
            {
            }
    
    
        }
