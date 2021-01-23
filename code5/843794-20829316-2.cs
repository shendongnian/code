    int affectedRows = (int)command.ExecuteNonQuery();
    
    if (affectedRows == 0)
    {
        //no records to UPDATE, will INSERT
        command.CommandText = "INSERT INTO PGP (PGP,Team) VALUES (?, ?)";
        command.Parameters.RemoveAt(2);
        //rows affected by INSERT statement
        affectedRows = (int)command.ExecuteNonQuery();
    }
    
    if (affectedRows > 0)
    {
        if (MessageBox.Show("Table Saved!", "Update", MessageBoxButtons.OK) == DialogResult.OK)
        {
            //refreshMyGrid
            RefreshMyDataGridView1();
        }
    }
