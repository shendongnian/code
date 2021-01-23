    public IEnumerable<T> ExecuteQuery<T>(string sql) where T : IFacetsObject<T>, new()
    {
        using (var conn = new AseConnection(_conn))
        {
            conn.Open();
            var cmd = new AseCommand(sql, conn);
    
            var dt = new DataTable();
            var da = new AseDataAdapter(sql, conn);
            da.Fill(dt);                
    
            return new T().ToObject(dt); //this is the interface method
        }
    }
