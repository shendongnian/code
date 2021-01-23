       protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {     
          bind1();
          Panel1.Visible = true;
        }
    }
     protected void TextBox1_TextChanged1(object sender, EventArgs e)
     {
       if(Panel1.Visible==true)
       {
           Panel1.Visible=false;
       }
       SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
       con.Open();
       SqlCommand cmd=new SqlCommand("select name from tbl_data_show",con);
       DataTable dt=new DataTable();
       SqlDataAdapter da=new SqlDataAdapter(cmd);
       da.Fill(dt);
       SqlDataReader dr=cmd.ExecuteReader();
       While(dr.Read())
       {
        if(dt.Rows.count>0)
        {
            if (TextBox1.Text == dr.GetString(0) || TextBox1.Text == "")
            {
                Panel1.Visible=true;
            }
            else 
            {
                Panel1.Visible=false;
            }
        }
      }  
      con.Close();
    }
