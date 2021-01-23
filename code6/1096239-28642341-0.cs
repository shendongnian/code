    if (koneksi_manual.con.State == ConnectionState.Open)    
       koneksi_manual.con.Close();
   
    for (int i = 0; i < gridView1.DataRowCount - 1; i++)// <= Use gridView1.DataRowCount instead of gridView1.RowCount.
    {    
        OracleCommand cmd = new OracleCommand();
    
        cmd.CommandText = @"INSERT INTO TEST (NAMA, ALAMAT) 
                VALUES ('" + gridView1.GetRowCellValue(i, "NAMA") +
                      "', '" + gridView1.GetRowCellValue(i, "ALAMAT") + "')";// <= Use gridView1.GetRowCellValue to get the cell value.
    
        cmd.Connection = koneksi_manual.con;
        koneksi_manual.con.Open();// <= Open connection before executing the command.
        cmd.ExecuteNonQuery(); //eror disini
        MessageBox.Show("DATA TELAH DISIMPAN");
        koneksi_manual.con.Close();
    }
