     while (reader.Read())
            {
                 P1.Value = reader.GetString(0);
                Com_Attendance.ExecuteNonQuery();
                Da.Fill(Ds);
             }
            dataGridView1.DataSource = Ds.Tables[0];
