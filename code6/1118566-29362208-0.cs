    var posts =
                    postList.GroupBy(p => p.PostId)
                            .Select(
                                g =>
                                new Post
                                    {
                                        PostId = g.Key,
                                        Categories =
                                            g.Select(p => p.Categories.FirstOrDefault())
                                            .Where(c => c != null).ToList()
                                    });
