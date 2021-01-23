    protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dtReturn = new DataTable();
            SqlConnection con = data.getKoneksi();
            con.Open();
            SqlCommand Perintah = new SqlCommand();
            Perintah.Connection = con;
            Perintah.CommandText = "SELECT DISTINCT Peminjaman.Katalog, Peminjaman.Pinjam, Peminjaman.Kembali, Pengguna.Nama, Buku.Judul, Buku.Jumlah, Temp.Kembali AS HrsKbl FROM Peminjaman INNER JOIN Buku INNER JOIN Temp ON Buku.ID = Temp.ID ON Peminjaman.Katalog = Buku.ID AND Peminjaman.Katalog = Temp.ID INNER JOIN Pengguna ON Peminjaman.Peminjam = Pengguna.NIS WHERE Peminjaman.Status = 'dipinjam' ORDER BY Kembali ASC";
            SqlDataAdapter Adapter = new SqlDataAdapter();
            Adapter.SelectCommand = Perintah;
            Adapter.Fill(dtReturn);
    
            ReportDocument rpt = new Laporan();
            rpt.Load(Server.MapPath("~/Laporan.rpt"));
            rpt.SetDataSource(dtReturn);
    
            CrystalReportViewer1.ReportSource = rpt;
            CrystalReportViewer1.DataBind();
            rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "Laporan");
            con.Close();
        }
