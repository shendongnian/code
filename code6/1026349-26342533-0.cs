    using (var sqlConnection = new SqlConnection(Consts.ConnectionString))
            {
                var lookup = new Dictionary<long, Post>();
                sqlConnection.Query<Post, Tag, Post>(@"
                SELECT P.*, T.*
                FROM Post P
                INNER JOIN PostTag PT ON (P.Id = PT.PostId)
                INNER JOIN Tag T ON PT.TagId = T.Id", (p, t) =>
                                                    {
                                                        Post post;
                                                        if (!lookup.TryGetValue(p.Id, out post))
                                                        {
                                                            lookup.Add(p.Id, post = p);
                                                        }
                                                        if (post.Tags == null)
                                                            post.Tags = new List<Tag>();
                                                        post.Tags.Add(t);
                                                        return post;
                                                    }).ToList();
                var resultList = lookup.Values;
            }
