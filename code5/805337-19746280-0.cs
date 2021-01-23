        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        {
            found = false;
            for (int j = 0; j < ds.Tables["Units"].Rows.Count; j++)
            {
                if (ds.Tables["Units"].Rows[j][0].ToString() == dataGridView1.Rows[i].Cells[0].Value.ToString())
                {
                    found = true;
                    break;
                }
            }
            if (found==false)
            {
                SqlCommand cmd;
                cmd = new SqlCommand("insert into Units (Unit_name) values (@name)", conn);
                cmd.Parameters.AddWithValue("@name", dataGridView1.Rows[i].Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("تمت الاضافه");
            }
        }
