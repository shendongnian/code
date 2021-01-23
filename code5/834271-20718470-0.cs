    // cypher-query to retrieve node Ids
    client.Cypher
       .Match("(n:SpatialIndex)")
       .Where("has(n.lat)")
       .AndWhere("has(n.lon)")
       .Return(node => node.Id());
    // add existing node to SimplePoint-Layer
    public void AddNodeToLayer(long nodeId, string layer)
    {
        string URINode = string.Format("{0}node/{1}",_client.BaseUrl, nodeId);
        string json = string.Format("{{\"layer\":\"{0}\", \"node\":\"{1}\"}}", layer, URINode);
    
        string URIAdd = string.Format("{0}ext/SpatialPlugin/graphdb/addNodeToLayer", _client.BaseUrl);
        HTTPCommand(new Uri(URIAdd), json);
     }
    
