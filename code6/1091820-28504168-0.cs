    var flattenedValues = (from grouping in Values
                            from ids in grouping
                            from id in ids
                            select new
                            {
                                Organization = grouping.Key,
                                QuestionId = id,
                            })
                            .ToList();
    DataContext.Answers.Where(a => a.Organization == CurrentUser.Organization ||
        flattenedValues.Contains(new
                            {
                                Organization = a.Organization,
                                QuestionId = a.QuestionId,
                            }));
