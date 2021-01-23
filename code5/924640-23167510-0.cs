    var r = context.Topics
                .Select ( s => new {
                        id = s.TopicId,
                        name = s.Name,
                        sid = s.SubTopics.Where(st=>st.TopicId==s.TopicId).Select( st => st.SubTopicId ),
                        sidname = s.SubTopics..Where(st=>st.TopicId==s.TopicId).Select ( st => st.Name)
                    }).
            ToList();
