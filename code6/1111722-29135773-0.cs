    a.FormClosed += FormClosed;
.....
    private void FormClosed(object sender, FormClosedEventArgs e)
    {
            SqlCommand sql = new SqlCommand("SELECT * FROM kas ORDER BY id_kas, tanggal DESC", koneksi.mykonek);
            koneksi.openkonek();
            SqlDataReader reader = sql.ExecuteReader();
            DataTable a = new DataTable();
            a.Load(reader);
            koneksi.closekonek();
            dgv.DataSource = a;
            dgv.Enabled = true;
        }
