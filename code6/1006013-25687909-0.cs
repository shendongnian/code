    var query = from classification in Enum.GetValues(typeof(ClassificationLevel)).Cast<ClassificationLevel>()
                join exam in context.Exams on classification equals exam.Classification into gj
                from subExam in gj.DefaultIfEmpty()
                select new { classification, exam = subExam };
    IDictionary<ClassificationLevel, Int32> stats = query
        .GroupBy(x => x.classification)
        .ToDictionary(g => g.Key, g => g.Count());
