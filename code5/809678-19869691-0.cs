    public Data Get(Request request)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.open();
    
                var data = new Data();
    
                data = GetData(connection);
                data.AppleData = GetGrapeData(connection);
                data.OrangeData = GetGrapeData(connection);
                data.GrapeData = GetGrapeData(connection);
        
                return data;
            }
            finally
            {
                connection.close()
            }
            
        }
    }
