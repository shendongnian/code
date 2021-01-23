    var dbSubTopics = db.SubTopics;
    var oldObj = dbSubTopics
        .Where(t => t.TopicId == id)
        .AsNoTracking()
        .ToList();
    var newObj = topic.SubTopics.ToList();
    foreach (var subTopic in newObj.Where(st => WasUpdated(st, oldObj))
    {
        dbSubTopics.Attach(subTopic);
        db.Entry(subTopic).State = EntityState.Modified;
    }
    dbSubTopics.AddRange(newObj.Where(st => WasAdded(st, oldObj));
    foreach (var subTopic in oldObj.Where(st => WasRemoved(st, newObj))
    {
        db.SubTopics.Attach(subTopic);
        db.SubTopics.Remove(subTopic);
    }
