    using (SqlConnection conn = new SqlConnection(@"Persist Security Info=False;Integrated Security=true;Initial Catalog=myTestDb;server=(local)"))
    {
        SqlCommand addSite = new SqlCommand(@"INSERT INTO site_list (site_name) VALUES (@site_name)", conn);
        addSite.Parameters.AddWithValue("@site_name", "mywebsitename");
        addSite.Connection.Open();
        addSite.ExecuteNonQuery();
        addSite.Connection.Close();
