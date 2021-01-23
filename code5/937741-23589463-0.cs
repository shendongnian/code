    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString="Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Administrator\\Documents\\Visual Studio 2010\\WebSites\\WebSite3\\App_Data\\name.mdf;Integrated Security=True;User Instance=True";
    
        SqlCommand cmd = new SqlCommand("insert into names values('" + TextBox1.Text + "')");
        cmd.Connection = conn; // <- this is the missing line
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    
    }
