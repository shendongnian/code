    using (var con = new SqlCeConnection("ConnectionString"))
    { 
        string strQuery = @"UPDATE test_group SET Main [Group] = @group, [Sub Group] = @subGroup WHERE [Group Id] = @groupID"
        using(var command = new SqlCeCommand(strQuery, con))
        {
            command.Parameters.AddWithValue("@group",comboBox1.Text);
            command.Parameters.AddWithValue("@subGroup",richTextBox2.Text );
            command.Parameters.AddWithValue("@groupID",richTextBox1.Text );
            con.Open();
            int updated = command.ExecuteNonQuery();
        }
    }
