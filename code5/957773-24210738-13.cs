    var oldObj = new List<SubTopic>();
    foreach(var t in db.SubTopics.AsNoTracking())
        if(t => t.TopicId == id)
            oldObj.Add(t);
    var newObj = new List<SubTopic>(topic.SubTopics);
    foreach (var subTopic in newObj)
    {
        foreach(var db1 in oldObj)
        {
            if((db1.SubTopicId == subTopic.SubTopicId) &&
                (db1.Number != subTopic.Number || !db1.Name.Equals(subTopic.Name)
                || !db1.Notes.Equals(subTopic.Notes)))
            {
                db.SubTopics.Attach(subTopic);
                db.Entry(subTopic).State = EntityState.Modified;
                break;
            }
        }
    }
    foreach (var subTopic in newObj)
    {
        foreach(var db1 in oldObj)
        {
            if(db1 => db1.SubTopicId != subTopic.SubTopicId)
            {
                db.SubTopics.Add(subTopic);
                break;
            }
        }
    }
    foreach (var subTopic in oldObj)
    {
        bool allMatch = true;
        foreach(var db1 in newObj)
        {
            if(subTopic.SubTopicId != db1.SubTopicId)
            {
                allMatch = false;
                break;
            }
        }
        if(allMatch)
        {
            db.SubTopics.Attach(subTopic);
            db.SubTopics.Remove(subTopic);
        }
    }
