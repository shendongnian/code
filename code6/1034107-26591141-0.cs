    public static string GetDataTableToJSONString(DataTable table) {
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
        foreach (DataRow row in table.Rows) {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns) {
                dict[col.ColumnName] = row[col];
            }
            list.Add(dict);
        }
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        serializer.MaxJsonLength = Int32.MaxValue;
        return serializer.Serialize(list);
    }
    public static List<string> GetAutoCompleteData(string searchText) {
        string sql = "SELECT TOP 1000 [SearchTerm] FROM [Search].[dbo].[Cache] " +
            "where AutoCompleteTerm = 0 and SearchTerm LIKE @SearchText + '%';";
        using (SqlConnection con = new SqlConnection(dbSearch)) {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con)) {
                cmd.Parameters.AddWithValue("@SearchText", searchText);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                    using (DataSet ds = new DataSet()) {
                        da.Fill(ds);
                        return GetDataTableToJSONString(ds.Tables[0]);
                    }
                }
            }
        }
    }
