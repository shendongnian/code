           DataTable m_DataTable = new DataTable();
            string theMagicWord = Request["k"];
            using (SqlConnection con = new SqlConnection("Connection information"))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select mBank_file.Id, mBank_file.Filename, CONVERT(varchar, mBank_file.TimeUploaded, 105) AS Time from mBank_file INNER JOIN mBank_keywords ON mBank_file.Id = mBank_keywords.fileId WHERE mBank_keywords.Keyword = @key ";
                    cmd.Parameters.AddWithValue("@key", theMagicWord);
                    cmd.Connection = con;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    m_DataTable.Load(dataReader);
                    con.Close();
                }
            }
            if (m_DataTable != null)
        {
            DataView m_DataView = new DataView(m_DataTable);
            SortingExpression = e.SortExpression + " " + (SortingExpression.Contains("ASC") ? "DESC" : "ASC");
            m_DataView.Sort = SortingExpression;
            GridView1.DataSource = m_DataView;
            GridView1.DataBind();
        }
        
