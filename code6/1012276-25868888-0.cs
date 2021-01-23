    // Somehow get the target Post and store it the post variable, then
    post.Comments.Add(comments)
    comments.Post = post;
    Session.Save(comments);
    Session.Save(post);
    Session.Commit();
