       protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {     
          bind1();
          //Panel1.Visible = true;
        }
    }
     protected void TextBox1_TextChanged1(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand("select name from tbl_data_show where name='"+TextBox1.Text+"'", con);
       // DataTable dt1 = new DataTable();
       // SqlDataAdapter da = new SqlDataAdapter(cmd);
       // da.Fill(dt1);
       SqlDataReader dr = cmd.ExecuteReader();
       if (dr.HasRows)
       {
           while (dr.Read())
           {
               Panel1.Visible = true;
               //if (dt1.Rows.Count > 0)
               //{
               //    if (TextBox1.Text == dr.GetString(0))
               //    {
               //        //Label1.Text = "4";
               //        //Label2.Text = "5";
               //        Panel1.Visible=true;
               //        //Label1.Visible = true;
               //        //Label2.Visible = false;
               //    }
               //    else
               //    {
               //        //Label2.Text = "5";
               //        Panel1.Visible = false;
               //        //Label2.Visible = true;
               //        //Label1.Visible = false;
               //    }
               //}
           }
       }
       else
       {
           Panel1.Visible = false;
       }
        con.Close();
    }
