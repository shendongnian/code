    using System.Data; // and project must reference System.Data.DataSetExtensions
    var ds = new DataSet();
    using (var conn = DbContext.Database.GetDbConnection())
    using (var cmd = conn.CreateCommand())
    {
      cmd.CommandType = CommandType.Text;
      cmd.CommandText = sqlText;
      conn.Open();
      (new SqlDataAdapter(cmd)).Fill(ds);
    }
    var rows = ds.Tables[0].AsEnumerable(); // AsEnumerable() is the extension
    var anons = rows
      .Select(r => new { Val = r["Val"] })
      .ToList();
