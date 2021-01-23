    public class UserResult
    {
        public User u { get; set; }
    }
    var results = graphClient.Cypher
        .Match("(u:User)")
        .Return<UserResult>("u")
        .Results;
    foreach (var result in results)
    {
        var user = result.u;
    }
