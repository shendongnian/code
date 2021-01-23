        while (reader.Read())
        {
            i = System.Convert.ToInt32(reader["id"].ToString());
            dataGridView1.Rows.Add();
            MessageBox.Show(System.Convert.ToString(i));
            DataGridViewRow R = dataGridView1.Rows[i-1];
            R.Cells["Column9"].Value = reader["firstname"].ToString();
            R.Cells["Column10"].Value = reader["lastname"].ToString();
        }
