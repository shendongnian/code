        using (MySqlConnection con = new MySqlConnection("server=SERVERIP;port=3306;database=data;uid=USER;password=PASS"))
        {
            con.Open(); // Hopefully no error here any more
            using (MySqlCommand cmd = new MySqlCommand("insert into info(Datum,Timmar,Rast) Values(@Datum,@Timmar,@Rast)", con))
            {
                cmd.Parameters.AddWithValue("@Datum", textBox1.Text);
                cmd.Parameters.AddWithValue("@Timmar", textBox2.Text);
                cmd.Parameters.AddWithValue("@Rast", textBox3.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sparat!");
            }
         }
