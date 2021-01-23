    private void button1_Click(object sender, EventArgs e)
    {
        string povezava = "........."
        string zapisi = "update Zaposleni set ID=?,Ime=?,Priimek=?,Uporabnisko_ime=?,Geslo=?," + 
                        "E_posta=?,Ulica=?,Hisna_stevilka=?,Mesto=?,Delovno_mesto=? " + 
                        "where ID=?";
        try
        {
            using(OleDbConnection baza = new OleDbConnection(povezava))
            using(OleDbCommand beri = new OleDbCommand(zapisi, baza))
            {
                baza.Open();
                beri.Parameters.AddWithValue("@p1",this.textBox1.Text);
                beri.Parameters.AddWithValue("@p2",this.textBox2.Text);
                beri.Parameters.AddWithValue("@p3",this.textBox3.Text);
                .... and so on for the other parameters
                beri.Parameters.AddWithValue("@p11",this.textBox1.Text);
                int rowsAffected = beri.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
