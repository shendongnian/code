    [Route("api/queries/{id:int}"]
    public Query GetQueryById(int id) { ... }
    
    [Route("api/queries/{name}"]
    public Query GetQueryByName(string name) { ... }
