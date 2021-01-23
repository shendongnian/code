    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ("Data Source=localhost;Initial Catalog=SeminarDB; Integrated security=true;");
        try
        {
            con.Open();
            string str = "select count(*) from Member where Username='" + signintext.Text + "' and Password='" + passwordtext.Text + "'";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr = cmd.ExecuteReader();
            string login = signintext.Text;
            string pwd = passwordtext.Text;
            while (dr.Read())
            {
                if ((dr[0] > 0)
                {
                    Label1.Text = "success!"; 
                }
                else
                {
                     Label1.Text = "failed!";
                }
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
}
