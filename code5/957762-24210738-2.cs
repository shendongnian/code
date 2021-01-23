    var oldObj = db.SubTopics
        .Where(t => t.TopicId == id)
        .AsNoTracking()
        .ToList();
    var newObj = topic.SubTopics.ToList();
    foreach (var subTopic in newObj)
    {
        if(oldObj.Any(db1 => (db1.SubTopicId == subTopic.SubTopicId) &&
                (db1.Number != subTopic.Number || !db1.Name.Equals(subTopic.Name)
                || !db1.Notes.Equals(subTopic.Notes))))
        {
            db.SubTopics.Attach(subTopic);
            db.Entry(subTopic).State = EntityState.Modified;
        }
    }
    foreach (var subTopic in newObj)
    {
        if(oldObj.All(db1 => db1.SubTopicId != subTopic.SubTopicId))
        {
            db.SubTopics.Add(subTopic);
        }
    }
    foreach (var subTopic in oldObj)
    {
        if(newObj.All(subTopic.SubTopicId != db1.SubTopicId))
        {
            db.SubTopics.Attach(subTopic);
            db.SubTopics.Remove(subTopic);
        }
    }
    
