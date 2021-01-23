      var result = client.Cypher.Start(new { s = string.Format("node({0})", id) })
                   .Match("(u:User)<-[mb:Created_By]-(c:Comment)-[o:On_Item]->(s:Session)")
                   .Merge("(c)-[lb:Liked_By]->(lbu:User)")  //bad line here
                   .Return((u, mb, c, s, o, lbu) => 
                         new { Comment = c.As<Comment>(), MadeByUser = u.Node<UserInfo>(),                  CommentNodeId = c.Id(), LikedByUsers = lbu.CollectAs<UserInfo>() })
                               .Results.Select(x =>
                               {
                                   x.Comment.MadeBy = x.MadeByUser.Data;
                                   x.Comment.MadeBy.NodeId = (int)x.MadeByUser.Reference.Id;
                                   x.Comment.MadeBy.ProviderUserKey = x.MadeByUser.Reference.Id;
                                   x.Comment.Id = (int)x.CommentNodeId;
                                   x.Comment.LikedBy = x.LikedByUsers.Select(ui => new UserInfo { Username = ui.Data.Username, ProviderUserKey = ui.Reference.Id, NodeId = (int)ui.Reference.Id }).ToList();
                                   return x.Comment;
                               });
