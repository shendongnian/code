     using (SqlConnection cn = new SqlConnection("CONNECTION STRING"))
    {
        cn.Open();
        FileStream fStream = File.OpenRead("C:\\MyFiles\\TempReport.pdf");
        byte[] contents = new byte[fStream.Length];
        fStream.Read(contents, 0, (int)fStream.Length);
        fStream.Close();
        using (SqlCommand cmd = new SqlCommand("insert into SavePDFTable " + "(PDFFile)values(@data)", cn))
       {
             cmd.Parameters.Add("@data", contents);
             cmd.ExecuteNonQuery();
             Response.Write("Pdf File Save in Dab");
       }
