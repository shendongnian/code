    private void button1_Click_1(object sender, EventArgs e)
    {
        conn.Open();
        SQLiteCommand comm = new SQLiteCommand("Select * From Patients", conn);
        using (SQLiteDataReader read = comm.ExecuteReader())
        {
            while (read.Read())
            {
                dataGridView1.Rows.Add(new object[] { 
                read.GetValue(0),  // U can use column index
                read.GetValue(read.GetOrdinal("PatientName")),  // Or column name like this
                read.GetValue(read.GetOrdinal("PatientAge")),
                read.GetValue(read.GetOrdinal("PhoneNumber")) 
                });
            }
        }
    }
