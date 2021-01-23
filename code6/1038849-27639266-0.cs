    if(!PostBack)
    {   
     string CSs = ConfigurationManager.ConnectionStrings["Koshur"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CSs))
            {
                string query = "select * from userdetails where Username='" + HttpContext.Current.User.Identity.Name.ToString() + "';";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "userdetails");
                firstnametext.Text=ds.Tables["userdetails"].Rows[0]["Firstname"].ToString();
                lastnametext.Text = ds.Tables["userdetails"].Rows[0]["Lastname"].ToString();
                dobtext.Text = ds.Tables["userdetails"].Rows[0]["Dateofbirth"].ToString();
                contacttext.Text = ds.Tables["userdetails"].Rows[0]["ContactNO"].ToString();
    
            }
    }
 
