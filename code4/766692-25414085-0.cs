    var update = Update.Set("Comments.$.Text", "new comment text");
    var query = Query.And(
       Query<User>.EQ(u => u.Id, userId),
       Query<User>.ElemMatch(u => u.Comments, eq => eq.EQ(c => c.Id, commentId)));
    userCollection.Update(query, update);
