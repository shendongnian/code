    private void PrintPreview()
    {
        try
        {
            if (gridView1.RowCount <= 0)
            {
                MessageBox.Show("DATA ROW KOSONG", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var table = new DataTable("V_KARYAWAN, KARYAWAN_GAMBAR");
                for (int rowHandle = 0; rowHandle < gridView1.DataRowCount; rowHandle++)
                {
                    //connection
                    if (koneksi.koneksi.con.State == ConnectionState.Open)
                    {
                        koneksi.koneksi.con.Close();
                    }
                    koneksi.koneksi.con.Open();
                    tambah buka = new tambah();
                    // Get the value for the given column - convert to the type you're expecting
                    var obj = gridView1.GetRowCellValue(rowHandle, "NIK");
                    using (var adp = new OracleDataAdapter(@"SELECT * FROM V_KARYAWAN, KARYAWAN_GAMBAR WHERE V_KARYAWAN.NIK = KARYAWAN_GAMBAR.KARYAWAN_FK AND V_KARYAWAN.NIK = '" + obj + "'", koneksi.koneksi.con))
                    {
                        adp.Fill(table);
                    }
                }
                DataSet ds = new DataSet();
                ds.Tables.Add(table);
                kartu report = new kartu();
                report.DataSource = ds.Tables[0];
                report.ShowPreview();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
