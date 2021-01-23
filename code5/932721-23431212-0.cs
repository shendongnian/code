    context.Posts
           .SelectMany(post => post.Packs
           .SelectMany(pack => pack.Files
           .Select(file => new PostModel
                           {
                              Id = post.Id,
                              File = file.Key,
                              Types = post.Types,
                              Title = post.PostsLocalized.First(pl => pl.Culture == culture).Title,
                              Body = post.PostsLocalized.First(pl => pl.Culture == culture).Body
                           })))
           .ToList();
