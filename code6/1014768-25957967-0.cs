    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string pdfUrl = string.Empty;
        string imgUrl = string.Empty;
        string cmdText = @"SELECT PDFUrl, ImgUrl FROM Book WHERE Id=@id";
        using(SqlConnection con = new SqlConnection(.....connectionstringhere....))
        using(SqlCommand cmd = new SqlCommand(cmdText, con))
        {
            con.Open();
            cmd.Parameters.AddWithValue("@id", TextBoxDelete.Text.Trim());
    
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                if(reader.Read())
                {
                   pdfUrl = reader.IsDbNull(0) ? string.Emty : reader[0].ToString();
                   pdfUrl = reader.IsDbNull(1) ? string.Emty : reader[1].ToString();
    
                   string fullPathPDF = pdfUrl.Length > 0 ? Server.MapPath(pdfUrl) : string.Empty;
                   string fullPathImg = imgUrl.Length > 0 ? Server.MapPath(imgUrl) : string.Empty;
                   if (File.Exists(fullPathPDF))
                       File.Delete(fullPathPDF);
                   if (File.Exists(fullPathImg))
                       File.Delete(fullPathImg);
    
    
                   reader.Close();
                   cmd.Command.Text = "DELETE FROM Book WHERE Id=@id";
                   cmd.ExecuteNonQuery();
                }
            }
        }
    }
