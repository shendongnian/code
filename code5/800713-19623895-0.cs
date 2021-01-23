    //posts.Add(new Note());
    //posts.Add(new Notification());
    //posts.Add(new Photo());
    posts.AddRange(notes);
    posts.AddRange(photos);
    posts.AddRange(notifications);
    // do the projection into Stream
    return (from n in posts
            select new Stream()
            {
                id = n.post_id,
                value = n.value,
                timestamp = n.timestamp,
                type = "note"
            }).ToList();
