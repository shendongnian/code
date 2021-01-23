For example, I like to use Dapper's connection.Query() syntax which will return results as an IEnumerable&lt;dynamic&gt;. Then you can create an object like this:
    public class DynamicQueryResult
    {
        public dynamic QueryResults {get; set;}
    }
