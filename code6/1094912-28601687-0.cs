    public static dynamic GetFactorProperties(int factornumber)
    {
        using (var db = new OleDbConnection(cs))
        {
             db.Open();
             var cmd = new OleDbCommand("SELECT * FROM FactorList WHERE FactorNumber = @0", db);
             cmd.Parameters.AddWithValue("@0", factornumber);
             var result = cmd.ExecuteReader();
             if(result.Read())
             {
                  dynamic obj = new ExpandoObject();
                  obj.FactorDate = result.GetString(0);
                  obj.FactorNumber = result.GetString(1);
                  // ...
                  return obj;
             }
             else
             {
                  return ProperiesObject();
             }
        }
    }
