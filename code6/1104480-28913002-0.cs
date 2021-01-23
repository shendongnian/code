            private void button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(@"Data Source=LUKA-PRENOSNIK\SQLEXPRESS;Database=Registracija;Trusted_Connection=True");
        SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Registracija WHERE Up_ime='" + tbUp_ime.Text + "' AND Geslo='" + tbGeslo.Text + "'", conn);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows[0][0].ToString() == "1")
        {
            this.Hide();
            Glavna g = new Glavna();
            g.Show();
            Close();
        }
        else
        {
            MessageBox.Show("Vnesena kombinacija uporabniškega imena in gesla nista pravilna!");
            
        }
