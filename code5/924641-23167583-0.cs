    var r = context.Topics.SelectMany(t => t.SubTopics
     .Select(st => new 
		{
			TopicID = t.TopicId, 
			TopicName = t.Name, 
			SubTopicID = st.SubTopicId,
			SubTopicName = st.Name
		}));
