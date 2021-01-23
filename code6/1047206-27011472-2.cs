    protected void Page_Load(object sender, EventArgs e)
            {        
                string bsname = Request.QueryString["bsname"];
                string bscode = Request.QueryString["bscode"];
                if (!string.IsNullOrEmpty(bsname))
                {
        
                   if (string.IsNullOrEmpty(txtBsName.Text))
                   {
                     SqlCommand cmd = new SqlCommand("select * from bs WHERE bscode=@bscode", conn);
                     SqlDataAdapter dadapter = new SqlDataAdapter();
                     conn.Open();
                     txtBsName.ReadOnly = false;
                     dadapter.SelectCommand = cmd;
                     cmd.Parameters.Add(new SqlParameter("@bscode", bscode));
                     SqlDataReader dr = cmd.ExecuteReader();
                     while (dr.Read())
                     {
                        lblBsCode.Text = dr["bscode"].ToString();
                        txtBsName.Text = dr["bsname"].ToString();
        
                     }
                     dr.Close();
                     conn.Close();
                  }
               }
           }
     protected void btnSave_Click(object sender, EventArgs e)
        {
               conn.Open();
               string UCODE = LblUcode.Text;
               SqlCommand cmd = new SqlCommand("update users Set uname=@Uname,ushortname=@Ushortname,pswd=HASHBYTES('MD5',@Pswd) where ucode=@UCODE", conn);
           
               cmd.Parameters.AddWithValue("@Uname",txtUserName.Text );
               cmd.Parameters.AddWithValue("@Ushortname",txtUserShortName.Text );
               cmd.Parameters.AddWithValue("@Pswd",txtPassword.Text );
               cmd.Parameters.AddWithValue("@UCODE", UCODE);
               cmd.ExecuteNonQuery();
               cmd.Dispose();
            
               ShowMessage("Company Data update Successfully......!");
            
               clear();
    }
