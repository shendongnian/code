    string strQuery = "UPDATE test_group SET Main Group = @grp, [Sub Group] = @sub " + 
                      "WHERE [Group Id] = @grpID";
    using(SqlCeCommand cmdSelect = new System.Data.SqlServerCe.SqlCeCommand(strQuery, con))
    {
       cmdSelect.Parameters.AddWithValue("@grp", comboBox1.Text);
       cmdSelect.Parameters.AddWithValue("@sub", richTextBox2.Text);
       cmdSelect.Parameters.AddWithValue("@grpID", richTextBox1.Text);
       cmdSelect.ExecuteNonQuery();
       updatedb();
       con.Close();
    }
