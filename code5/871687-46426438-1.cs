    string query = String.Format("UPDATE games SET name='{1}', cost={2}, number={4} WHERE serial={0}",
                                serial.Text, name.Text, cost.Text, number.Text);
    SqlConnection connect = new SqlConnection(connectionString);
    SqlCommand cmd = new SqlCommand(query, connect);
    connect.Open();
    cmd.ExecuteNonQuery();
    connect.Close();
    this.gv.EditIndex = -1;
    BindTheGridView();
}
