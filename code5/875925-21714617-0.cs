    [System.Web.Http.HttpGet]
    public IEnumerable<Node> GetNodes() {
       IEnumerable<Node> nodes;
       ...
       // code to get Nodes from DB goes here
       ...
       return nodes;
    }
