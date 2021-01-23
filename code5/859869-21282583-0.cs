    List<Node> data = new List<Node>();
    while (reader.Read())
    {
       Node n = new Node();
    
       n.Timestamp = reader.GetDateTime(0); // TODO: Check column numbers
       n.Value = reader.GetFloat(1);
       n.NodeName = reader.GetString(2);
    
       data.Add(n);
    }
