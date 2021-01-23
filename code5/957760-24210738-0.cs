    var oldObj = db.SubTopics
        .Where(t => t.TopicId == id)
        .AsNoTracking()
        .ToList();
    var newObj = topic.SubTopics.ToList();
    var upd = newObj
        .Where(wb => oldObj
            .Any(db1 => (db1.SubTopicId == wb.SubTopicId) &&
                (db1.Number != wb.Number || !db1.Name.Equals(wb.Name)
                || !db1.Notes.Equals(wb.Notes))));
    var add = newObj
        .Where(wb => oldObj
            .All(db1 => db1.SubTopicId != wb.SubTopicId));
    var del = oldObj
        .Where(db1 => newObj
            .All(wb => wb.SubTopicId != db1.SubTopicId));
    foreach (var subTopic in upd)
    {
        db.SubTopics.Attach(subTopic);
        db.Entry(subTopic).State = EntityState.Modified;
    }
    foreach (var subTopic in add)
    {
        db.SubTopics.Add(subTopic);
    }
    foreach (var subTopic in del)
    {
        db.SubTopics.Attach(subTopic);
        db.SubTopics.Remove(subTopic);
    }
    
