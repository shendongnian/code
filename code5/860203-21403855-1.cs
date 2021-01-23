    ObjectiveDetail objectiveD = _uow.ObjectiveDetail.Get(1);
    SubTopic subTopic = _uow.SubTopic.Get(1); //SubTopic to remove
    SubTopic topicToAdd = _uow.SubTopic.Get(2); //SubTopic to add
    ObjectiveDetail.SubTopics.Remove(subTopic); //Remove the entity from the ObjectiveTopic table
    ObjectiveDetail.SubTopics.Add(topicToAdd); //Add the new entity, will create a new row in ObjectiveTopic Table
    _uow.ObjectiveDetail.Update(objectiveD);
