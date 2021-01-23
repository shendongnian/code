    //assume input is List of integers 
    List<int> ids = new List<int> { 1,5,6,9 };
    //build your SQL statement as below
    string cmdText = "SELECT * FROM Table  WHERE id IN ({0})";
    // add parameters for each id value 
    string[] paramNames = ids.Select(
        (s, i) => "@id" + i.ToString()
    ).ToArray();
    
    string inClause = string.Join(",", paramNames);
    //set the parameter values
    using (SqlCommand cmd = new SqlCommand(string.Format(cmdText, inClause))) {
        for(int i = 0; i < ids.Count; i++) {
           cmd.Parameters.AddWithValue(paramNames[i], ids[i]);
        }
    }
