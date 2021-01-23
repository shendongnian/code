    private void GetResults(string username, string tagValue)
    {
        var query = Client.Cypher
            .Match("(o)-[r]-(post:Post)-[:HAS_MentionedUsers]->(assignee:User)")
            .Where((User assignee) => assignee.UserName == username)
            .Return((post, o, r) => new {Post = post.As<Post>(), O = o.As<object>(), R = r.As<RelationshipInstance<object>>()})
            .Union()
            .Match("(o)-[r]-(post:Post)-[:HAS_MentionedUsers]->(hashTag:HashTag)")
            .Where((HashTag hashTag) => hashTag.Value == tagValue)
            .Return((post, o, r) => new {Post = post.As<Post>(), O = o.As<object>(), R = r.As<RelationshipInstance<object>>()});
        var res = query.Results.ToList();
    }
