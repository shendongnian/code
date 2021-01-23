    if (Request.QueryString["ReqID"] != null)
        ReqID = this.Request.QueryString["ReqID"];
    using (SqlConnection sqlc = new SqlConnection(ConnectionString))
    {
        using (SqlCommand cmd = new SqlCommand("LoadReq", sqlc))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            if (!this.IsPostBack)
            {
                if (ReqID != "")
                {
                    cmd.Parameters.Add("@ReqID", SqlDbType.NChar).Value = ReqID;
                    sqlc.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string[] textbox = new string[reader.FieldCount];
                        while (reader.Read())
                        {
                            textbox[2] = reader.GetString(reader.GetOrdinal("FReqID"));
                            textbox[3] = reader.GetString(reader.GetOrdinal("OrderDate"));
                            textbox[4] = reader.GetString(reader.GetOrdinal("OrderTime"));
                            textbox[5] = reader.GetString(reader.GetOrdinal("ReqIP"));
                            textbox[6] = reader.GetString(reader.GetOrdinal("Status"));
                            textbox[7] = reader.GetString(reader.GetOrdinal("FileCode"));
                            textbox[8] = reader.GetString(reader.GetOrdinal("Type"));
                            textbox[9] = reader.GetString(reader.GetOrdinal("DOI"));
                            textbox[10] = reader.GetString(reader.GetOrdinal("PubMedID"));
                            textbox[11] = reader.GetString(reader.GetOrdinal("PaperCode"));
                            LoadCorrectForm(textbox[8], textbox);
                        }
                    }
                }
                
                ...
            }
        }
    }
