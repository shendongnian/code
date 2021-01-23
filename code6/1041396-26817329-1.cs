    protected void Page_Load(object sender, EventArgs e)
    {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Guillermo\Desktop\HorsensHospital\App_Data\HospitalDB.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT [Task_temp_name], [Task_templatesID] FROM [Task_templates]", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            cmd.ExecuteNonQuery();
            con.Close();
}
