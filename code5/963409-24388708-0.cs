    DayOfWeek[] weekEnd = { DayOfWeek.Saturday, DayOfWeek.Sunday };
    DateTime end = Enumerable.Range(0, int.MaxValue)
                .Select(i => DateTime.Today.AddDays(i))
                .Where(d => !weekEnd.Contains(d.DayOfWeek))
                .Take(10)
                .Last();
