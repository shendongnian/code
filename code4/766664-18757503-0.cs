    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dtMsg = new DataTable();
        string strConn = cConnection.GetConnectionString();
        SqlConnection conn = new SqlConnection(strConn);
        SqlCommand sqlCMD = new SqlCommand("GetHomeMessage", conn);
        sqlCMD.CommandType = CommandType.StoredProcedure;
        sqlCMD.Parameters.Add("@Lang", SqlDbType.VarChar).Value = "Afrikaans";
        SqlDataAdapter sdaStat = new SqlDataAdapter(sqlCMD);
        sdaStat.Fill(dtMsg);
        if (dtMsg.Rows != null && dtMsg.Rows.Count > 0)
        {
            txtMessageBody.Html = dtMsg.Rows[0][0].ToString();
            MemoryStream stream = new MemoryStream();
            txtMessageBody.Export(DevExpress.Web.ASPxHtmlEditor.HtmlEditorExportFormat.Txt, stream);
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            string msgBody = reader.ReadToEnd();
            msgBody = msgBody.Trim();
            stream.Close();
            reader.Close();
            Font font = new Font("Arial", 16, FontStyle.Regular);
            Size size = TextRenderer.MeasureText(msgBody, font);
            
            txtMessageBody.Height = size.Height;
            txtMessageBody.SettingsResize.AllowResize = true;
            txtMessageBody.SettingsResize.MinWidth = 740;
        }
    }
