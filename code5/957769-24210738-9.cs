    var oldObj = db.SubTopics
        .Where(t => t.TopicId == id)
        .AsNoTracking()
        .ToList();
    var newObj = topic.SubTopics.ToList();
    foreach (var subTopic in newObj
        .Where(wb => oldObj
            .Any(db1 => (db1.SubTopicId == wb.SubTopicId) &&
                (db1.Number != wb.Number || !db1.Name.Equals(wb.Name)
                || !db1.Notes.Equals(wb.Notes)))))
    {
        db.SubTopics.Attach(subTopic);
        db.Entry(subTopic).State = EntityState.Modified;
    }
    foreach (var subTopic in newObj
        .Where(wb => oldObj
            .All(db1 => db1.SubTopicId != wb.SubTopicId)))
    {
        db.SubTopics.Add(subTopic);
    }
    foreach (var subTopic in oldObj
        .Where(db1 => newObj
            .All(wb => wb.SubTopicId != db1.SubTopicId)))
    {
        db.SubTopics.Attach(subTopic);
        db.SubTopics.Remove(subTopic);
    }
