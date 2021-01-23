    public class QueryObj
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public Result Get([FromUri] QueryObj queryObj)
    {...}
    http://.../query?Id=1&Name=test
