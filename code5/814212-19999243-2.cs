    private void Form1_Load(object sender, EventArgs e)
    {
        using (var con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Public\Database1.accdb;"))
        {
            con.Open();
            using (var cmd = new OleDbCommand("SELECT LastName, FirstName, Photo FROM Clients WHERE ID=3", con))
            {
                OleDbDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                this.textBox1.Text = rdr["FirstName"].ToString();
                this.textBox2.Text = rdr["LastName"].ToString();
                byte[] photoBytes = (byte[])rdr["Photo"];
                var ms = new System.IO.MemoryStream(photoBytes);
                this.pictureBox1.Image = new System.Drawing.Bitmap(ms);
                ms.Close();
            }
            con.Close();
        }
    }
