    public IList<Objective> GetObjectives(int examId)
        {
            var objectives = _objectivesRepository
                .GetAll()
                .Where(o => o.ExamId == examId || examId == 0)
                .Include(o => o.ObjectiveDetails.OrderBy(d => d.Number))
                .OrderBy(o => o.Number);
                .ToList();
            return objectives;
        }
