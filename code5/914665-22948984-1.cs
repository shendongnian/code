    RepositoryFactory.CreateReadOnly<MyEntity>()
        .Where(at => at.AccessedDate.HasValue 
            && at.CreatedDate >= startDate && at.CreatedDate <= endDate
            && SqlFunctions.DateDiff("ss", at.CreatedDate, at.AccessedDate.Value) > 0)
        .GroupBy(at => at.Participant.Id)
        .Select(at => new TimeOnSite {
            TimeSpentInSeconds = at.Sum(p => 
                SqlFunctions.DateDiff("ss", p.CreatedDate, p.AccessedDate.Value)
            ),
            // p.AccessedDate.Value.Subtract(p.CreatedDate).TotalSeconds), 
            ParticipantId = at.Key
        })
        .ToList();
