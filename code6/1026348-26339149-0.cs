    var sql = 
    @"
    select Id, Title, Body from Post where Id = @id
    select Id, Title from Tag t join PostTag pt on pt.TagId = p.Id where pt.PostId = @id";
    
    using (var multi = connection.QueryMultiple(sql, new {id=postId}))
    {
       var post = multi.Read<Post>().Single();
       var tags= multi.Read<Tag>().ToList();
       post.Tags = tags;
    } 
