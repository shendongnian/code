    public List<string> GetData(){
        // ...
        List<string> data = new List<string>();
        while (reader.Read())
        {
            data.Add(reader["total"].ToString());
        }
        return data; 
    }
