    public class Parameter
    {
        public string ParamName { get; set; }
        public ParamType ParamType { get; set; }
        public int Value { get; set; }
    }
    var parameterQuery = Query.And(Query<Parameter>.EQ(p => p.ParamName, "Target Temperature"), Query<Parameter>.GT(p => p.Value, 15));
