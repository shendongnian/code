    .Where(m => m.Problem != null && 
                m.Problem.SubTopic ! null && 
                m.Problem.SubTopic.Topic != null &&
                m.Problem.SubTopic.Topic.SubjectId == 0)
    .Select(m => m.QuestionId);
