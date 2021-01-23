         SqlCeCommand cmd1;
        for (int i = 0; i < table.Rows.Count; i++)
        {
            cmd1 = new SqlCeCommand("Insert into Master values('" + table.Rows[i].ItemArray[0].ToString() + "')", con);
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();
        }
