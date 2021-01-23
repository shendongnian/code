    SqlCommand cmd = new SqlCommand(sql, con);
    int nbrUpdates = cmd.ExecuteNonQuery();
    con.Close();
    if (nbrUpdates>0) MessageBox.Show("One item updated updated!");
    else MessageBox.Show(sql);
