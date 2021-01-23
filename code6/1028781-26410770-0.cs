    public Boolean executeNonQueries(string query02, Dictionary<string, object> parameters)
    {
        // Your existing code to setup connection
        foreach (var param in dictionaryWithParametersAndValues)
        {
            com.AddWithValue(param.Key, param.Value);
        }
        com.ExecuteNonQuery(); 
        // Rest of your existing code
    }
