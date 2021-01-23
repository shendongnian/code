    string name = "";
    string password = "";
    var stringWriter = new StringWriter();
    var writer = new XmlTextWriter(stringWriter) { Formatting = Formatting.Indented };    
    var tbl = new DataTable();
    string strConn = WebConfigurationManager.ConnectionStrings["TestConnection"].ToString();
    var conn = new SqlConnection(strConn);
    using (conn)
    {
        conn.Open();
        var cmd = new SqlCommand("GetUserLoginID", conn) {CommandType = CommandType.StoredProcedure};
        cmd.Parameters.AddWithValue("@UID", uid);
        cmd.Parameters.AddWithValue("@BID", bId);
        var userRecord = new SqlDataAdapter(cmd);
        userRecord.Fill(tbl);
        if (tbl.Rows.Count > 0)
        {
            var row = tbl.Rows[0];
            name = row["Name"].ToString();
            password = row["Password"].ToString();
            code = row["Code"].ToString();
        }
        tbl.Clear();
        cmd = new SqlCommand("GetUserDetails", conn) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddWithValue("@Code", code);
        cmd.Parameters.AddWithValue("@BID", bId);
        userRecord = new SqlDataAdapter(cmd);
        userRecord.Fill(tbl);
        if (tbl.Rows.Count > 0)
        {
            var row = tbl.Rows[0];
            writer.WriteStartDocument();
            writer.WriteStartElement("Root");
            writer.WriteElementString("BID", row["BID"].ToString());
            writer.WriteElementString("Name", name);
        }
        else
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("Root");
            writer.WriteElementString("BID", "Error");
        }
        writer.WriteEndElement();
        writer.Flush();
        writer.Close();
        conn.Close();
    }
    tbl.Dispose();
