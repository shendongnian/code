    string insert = string.Empty;
    for(int i = 0; i < table.rows.Count; i++)
    {
        insert += "Insert into Master values('" + table.Rows[i].ItemArray[0].ToString() + "');";
        if(i % 1000 == 0 || i+1 == table.rows.Count)
        {
            cmd1 = new SqlCeCommand(insert, con);
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();
            insert = string.Empty;
        }   
    }
