    protected void Button1_Click(object sender, EventArgs e)
        {
            string sONbr = sONbrTextBox.Text;
            string SOLine = sOLineTextBox.Text;
            string SerialNbr = serialNbrTextBox.Text;
            string StatusCode = statusCodeComboBox.Text;
            string CrUserID = Request.QueryString["LogInUser"].ToString();
    
            if (string.IsNullOrWhiteSpace(sONbr) || string.IsNullOrWhiteSpace(SOLine) || string.IsNullOrWhiteSpace(StatusCode) || string.IsNullOrEmpty(SerialNbr))
            {
                status_lbl.Text = "Please fill in all the information.";
                status_lbl.Visible = true;
                GridView1.Visible = false;
                return;
            }
    
            else if (string.IsNullOrWhiteSpace(CrUserID))
            {
                status_lbl.Text = "Please login your account!";
                status_lbl.Visible = true;
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Please login your account!')</script>");
                Response.Redirect("Login Page.aspx");
                GridView1.Visible = false;
                return;
            }
    
            else if (CheckBox1.Checked == true)
            {
    
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr_BCSystem"].ToString());
                conn.Open();
    
                SqlCommand comm = conn.CreateCommand();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "usp_TagNumberUpdate";
    
                comm.Parameters.AddWithValue("@sONbr", sONbr);
                comm.Parameters.AddWithValue("@SOLine", SOLine);
                comm.Parameters.AddWithValue("@SerialNbr", SerialNbr);
                comm.Parameters.AddWithValue("@StatusCode", StatusCode);
                comm.Parameters.AddWithValue("@CrUserID", CrUserID);
    
                SqlParameter ReturnVal = comm.Parameters.Add("@return", SqlDbType.NVarChar, 200);
                ReturnVal.Direction = ParameterDirection.Output;
    
                comm.ExecuteNonQuery();
    
                string val = (string)ReturnVal.Value;
    
                conn.Close();
                Response.Redirect(Request.RawUrl+"?status="+val);
    
            }
    
            else 
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr_BCSystem"].ToString());
                conn.Open();
    
                SqlCommand comm = conn.CreateCommand();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "usp_TagNumberUpdateNoSN";
    
                comm.Parameters.AddWithValue("@sONbr", sONbr);
                comm.Parameters.AddWithValue("@SOLine", SOLine);
                comm.Parameters.AddWithValue("@StatusCode", StatusCode);
                comm.Parameters.AddWithValue("@CrUserID", CrUserID);
    
                SqlParameter ReturnVal = comm.Parameters.Add("@return", SqlDbType.NVarChar, 200);
                ReturnVal.Direction = ParameterDirection.Output;
    
                comm.ExecuteNonQuery();
    
                string val = (string)ReturnVal.Value;
    
                conn.Close();
                Response.Redirect(Request.RawUrl+"?status="+val);
            }
        }
