    private static bool WasUpdated(SubTopic topic, IEnumerable<SubTopic> oldSubTopics)
    {
        //Find all the subtopics in the old sub topics with the same subtopic id:
        var sameID = oldSubTopics.Where(db1 => db1.SubTopicId == topic.SubTopicId);
        //If there are any here that don’t match on number, name and notes, then they have changed:
        return sameID.Any(db1 => db1.Number != topic.Number || !db1.Name.Equals(topic.Name) || !db1.Notes.Equals(topic.Notes));
        
        //Note, if there can be only one subtopic with a given ID, then we would be both clearer and fastere with:
        var oldTopic = oldSubTopics.FirstOrDefault(db1 => db1.SubTopicId == topic.SubTopicId);
        return oldTopic != null &&
            (oldTopic.Number != topic.Number || !oldTopic.Name.Equals(topic.Name) || !oldTopic.Notes.Equals(topic.Notes));
    }
    private static bool WasAdded(SubTopic topic, IEnumerable<SubTopic> oldSubTopics)
    {
        //If there’s no matching topic here, it was added.
        return !oldSubTopics.Any(old => old.SubTopicId == topic.SubTopicID);
    }
    private static bool WasRemoved(SubTopic topic, IEnumerable<SubTopic> newSubTopics)
    {
        //If there’s no matching topic here, it was removed.
        return !newSubTopics.Any(newST => newST.SubTopicId == topic.SubTopicID);
    }
