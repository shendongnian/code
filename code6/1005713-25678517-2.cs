    string[] ips = new string[] { "192.168.0.1", "192.168.0.2", "192.168.0.3" };
    string[] parameters = ips.Select(
        (ip, index) => "@ip" + index.ToString()
    ).ToArray();
    
    string commandFormat = "SELECT * FROM LOCATION WHERE IP_ADDRESS IN ({0})";
    string parameterText = string.Join(",", parameters);
    string commandText = string.Format(commandFormat, parameterText);
    
    using (SqlCommand command = new SqlCommand(commandText)) {
        for(int i = 0; i < parameters.Length; i++) {
           command.Parameters.AddWithValue(parameters[i], ips[i]);
        }
    }
