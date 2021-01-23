    public IList<Objective> GetObjectives(int examId)
    {
        var objectives = _objectivesRepository
            .GetAll()
            .Where(o => o.ExamId == examId || examId == 0)
            .Include(o => o.ObjectiveDetails)
            .ToList();
        return objectives.OrderBy(o => o.Number)
            .Select(o => {
                var record = o;
                record.ObjectiveDetails = record.ObjectiveDetails.OrderBy(d => d.Number).ToList();
                return record;
            });
    }
