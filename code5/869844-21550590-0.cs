    using (SqlConnection connection = new SqlConnection(
               ConfigurationManager.ConnectionStrings["ARM_TSPConnectionString"].ConnectionString))
    {
        string upd = "UPDATE Info SET Name=@Name, SecondName=@SecondName, Graduate=@Graduate, Class=@Class WHERE ID=@ID";
        SqlCommand cmd = new SqlCommand(upd, connection);
        cmd.Parameters.AddWithValue("@ID", IDLBL.Text);
        cmd.Parameters.AddWithValue("@SecondName", SName.Text);
        cmd.Parameters.AddWithValue("@Graduate", Ocenka.SelectedValue);
        cmd.Parameters.AddWithValue("@Class", Klass.SelectedValue);
        cmd.Parameters.AddWithValue("@Name", Name.Text);
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
    }
