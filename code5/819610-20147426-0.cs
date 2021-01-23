    public IEnumerable<T> GetRows(string sql, Action<SqlParameterCollection> addParameters, Func<IDataRecord, T> copyRow)
    {
         using (var cn = new SqlConnection("Connection string here"))
         using (var cmd = new SqlCommand(sql, cn)
         {
             cmd.CommandType = CommandType.StoredProcedure;
             addParameters(cmd.Parameters);
             cn.Open();
             using (var rdr = cmd.ExecuteReader())
             {
                 while (rdr.Read())
                 {
                     yield return copyRow(rdr);
                 }
                 rdr.Close();
             }
         }
    }
    public IEnumerable<MenuItem> GetChildMenus(string url)
    {
         return GetRows("spR_GetChildMenus", p =>
         {
             p.AddWithValue("@PageUrl", url);
             p.AddWithValue("@MenuId", ParameterDirection.Output);
             p.AddWithValue("@ParentId", ParameterDirection.Output);
             p.AddWithValue("@TitleText", ParameterDirection.Output);
             p.AddWithValue("@ExternalUrl", ParameterDirection.Output);
             p.AddWithValue("@FullUrl", ParameterDirection.Output);
             p.AddWithValue("@ChildCount", ParameterDirection.Output);
         }, r =>
         {
             return new MenuItem( ... );
         }
     }
