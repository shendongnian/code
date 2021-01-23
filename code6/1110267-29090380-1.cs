    protected void Button2_Click(object sender, EventArgs e)
    {
        for (int i = ListBox2.Items.Count - 1; i >= 0; i--)
        {
            if (ListBox2.Items[i].Selected)
            {
                ListBox3.Items.Add(ListBox2.Items[i]);
                string[] splits = ListBox2.Items[i].ToString().Split(new char[]{' ', ','}); // For splitting both empty space and comma (you've used in ur question)
                SqlCommand cmd = new SqlCommand("Insert Into [CopyUser_TBL_DB] ([ID], [Firstname], [Middlename], [Lastname]) Values (@ID, @FName, @MName, @LName)", conn);
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(splits[0]);
                cmd.Parameters.Add("@FName", SqlDbType.VarChar).Value = splits[1];
                cmd.Parameters.Add("@MName", SqlDbType.VarChar).Value = splits[2];
                cmd.Parameters.Add("@LName", SqlDbType.VarChar).Value = splits[3];
                cmd.ExecuteNonQuery();
                ListBox2.Items.RemoveAt(i);
            }
        }
    }
