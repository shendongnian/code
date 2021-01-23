        SqlConnection con = new SqlConnection();
        con.ConnectionString = ("Data Source=localhost;Initial Catalog=SeminarDB; Integrated security=true;");
        try
        {
            con.Open();
            string str = "select * from Member where Username='" + signintext.Text + "' and Password='" + passwordtext.Text + "'";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                
                 Label1.Text = "success!";
                 visibl = true;
            }
            else
            {
                 Label1.Text = "failed!";
            }    
               
            con.Close();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
}
