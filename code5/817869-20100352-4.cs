    private void btnStart_Click(object sender, EventArgs e)
    {
        using (var con = new OleDbConnection())
        {
            con.ConnectionString =
                    @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                    @"Data Source=C:\__tmp\test\Bd Fotos Equipamentos 2.mdb;";
            con.Open();
            using (OleDbCommand cmdIn = new OleDbCommand(), cmdOut = new OleDbCommand())
            {
                cmdOut.Connection = con;
                cmdOut.CommandText = "UPDATE [Fotografias e Manuais de Equipamentos] SET [FOTO]=? WHERE [ID]=?";
                cmdOut.Parameters.Add("?", OleDbType.VarBinary);
                cmdOut.Parameters.Add("?", OleDbType.Integer);
                cmdIn.Connection = con;
                cmdIn.CommandText = "SELECT [ID], [FOTO] FROM [Fotografias e Manuais de Equipamentos]";
                OleDbDataReader rdr = cmdIn.ExecuteReader();
                while (rdr.Read())
                {
                    int i = Convert.ToInt32(rdr["ID"]);
                    lblStatus.Text = string.Format("Processing ID {0}...", i);
                    lblStatus.Refresh();
                    byte[] b = (byte[])rdr["FOTO"];
                    byte[] imageBytes = OleImageUnwrap.GetImageBytesFromOLEField(b);
                    byte[] pngBytes;
                    using (MemoryStream msIn = new MemoryStream(imageBytes), msOut = new MemoryStream())
                    {
                        Image img = Image.FromStream(msIn);
                        img.Save(msOut, System.Drawing.Imaging.ImageFormat.Png);
                        img.Dispose();
                        pngBytes = msOut.ToArray();
                    }
                    cmdOut.Parameters[0].Value = pngBytes;
                    cmdOut.Parameters[1].Value = rdr["ID"];
                    cmdOut.ExecuteNonQuery();
                }
            }
            con.Close();
        }
        this.Close();
    }
