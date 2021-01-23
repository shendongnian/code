    protected void Button1_Click(object sender, EventArgs e)
    {
    
        using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Administrator\\Documents\\Visual Studio 2010\\WebSites\\WebSite3\\App_Data\\name.mdf;Integrated Security=True;User Instance=True"))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into names values(@name)", conn);
            // Alternatively, you could do cmd.Connection = conn if you didn't pass
            // the connection object into the SqlCommand constructor
            cmd.Parameters.AddWithValue("@name", TextBox1.Text);
            cmd.ExecuteNonQuery();
        }
     }
