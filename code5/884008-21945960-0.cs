    public ActionResult CreatePost([Bind(Include = "Id,Title,ShortDescription,Description,Published,PostedOn,ModifiedOn,CategoryId")] Post post, int[] postTags)
            {
                if (postTags != null)
                {
                    foreach (var t in postTags)
                    {
                        var tag = _dbTag.GetById(t);
                        post.Tags.Add(tag);
                    }
                }
               // save to database and other stuff
               return View(post);
            }
