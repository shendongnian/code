    using (var con = new SqlConnection(
        ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
    using (var cmd = con.CreateCommand())
    {
        const string query = "select [PDFFilePath] from [dbo].[AdmPDFManage] Where [PdfId] = (SELECT MAX([PdfId]) FROM [dbo].[AdmPDFManage]) ";
        cmd.CommandText = query;
        con.Open();
        using(var rd = cmd.ExecuteReader())
        {
            while (rd.Read())
            {
                string str = rd[0].ToString();
                // .. do something
            }
        }
    }
