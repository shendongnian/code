    private void button2_Click(object sender, EventArgs e)
    { // Open the connection using the connection string.
        SqlConnection con = new SqlConnection(@"Data Source=WIN-6Q836P8JQ1C\oby;Initial Catalog=Etudiant;Integrated Security=True");
        con.Open();
        string sqlQuery = "INSERT INTO Abscence (CIN,Heure_debut,Heure_fin,Date)";
        sqlQuery += "VALUES (@CIN, @Heure_debut, @Heure_fin, @Date)";
            // Insert into the Sql table. ExecuteNonQuery is best for inserts.
            using (SqlCommand com = new SqlCommand(sqlQuery, con))
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    com.Parameters.AddWithValue("@CIN", dataGridView1.Rows[i].Cells["CIN"].Value);
                    com.Parameters.AddWithValue("@Heure_debut", dataGridView1.Rows[i].Cells["column1"].Value);
                    com.Parameters.AddWithValue("@Heure_fin",dataGridView1.Rows[i].Cells["column2"].Value);
                    com.Parameters.AddWithValue("@Date", dateTimePicker1.Text);   
                }
                com.ExecuteNonQuery();
                com.Parameters.Clear();
                con.Close();
            }
        }
    }
