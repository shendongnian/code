    string str = 
            "UPDATE [MIX] SET " + 
            "[Stock quantity] = ?, " +
            "[Retail price] = ?, " +
            "[Original price] = ? " +
            "WHERE [Brand name] = ?";
    OleDbCommand comd = new OleDbCommand(str, conn);
    comd.Parameters.AddWithValue("?", comboBox1.Text);  // [Stock quantity]
    comd.Parameters.AddWithValue("?", comboBox4.Text);  // [Retail price]
    comd.Parameters.AddWithValue("?", comboBox5.Text);  // [Original price]
    comd.Parameters.AddWithValue("?", comboBox3.Text);  // [Brand name]
    comd.ExecuteNonQuery();
