    OleDbCommand com = new OleDbCommand(
            "insert into player_reg (p_name, f_name, dob, pob, sex, marital, nation, address, state, mob, email, course, college, y_year, sports, voter)" +
            "values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", con);
    com.Parameters.AddWithValue("?", TextBox1.Text);  // p_name
    com.Parameters.AddWithValue("?", TextBox2.Text);  // f_name
    com.Parameters.AddWithValue("?", TextBox3.Text);  // dob
    // ...and so on...
    com.Parameters.AddWithValue("?", TextBox16.Text);  // voter
    com.ExecuteNonQuery();            
