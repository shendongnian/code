    var objectives = _objectivesRepository
            .GetAll()
            .Where(o => o.ExamId == examId || examId == 0)
            .Include(o => o.ObjectiveDetails)
            .Select(x => new Objective {
                ObjectiveId = x.Id,
                ExamId = x.ExamId,
                Number = x.Number,
                ObjectiveDetails = x.ObjectiveDetails.OrderBy(d => d.Number)
            })
            .OrderBy(x => x.Number)
            .ToList();
    return objectives;
