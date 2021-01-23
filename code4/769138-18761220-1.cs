    return gradeData
        .GroupBy(row => row.Name)
        .Select(g => new Dealers
        {
            Name = g.Key.Name,
            TotalPoints = g.Sum(x => CalculateGrade(Convert.ToDouble(x.RecievedPoints),
                                                    x.MaxPoints,
                                                    Convert.ToDouble(x.Weightage)))
        })
        .ToList();
