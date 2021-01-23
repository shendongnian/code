    List<TrainScheduleViewModel> viewModels = query.Fetch(x => x.DaysOfWeek)
        .Select(t => new TrainScheduleViewModel
                    {
                        Id = t.Id,
                        ...
                        DaysOfWeek = BuildDaysOfWeek(t.DaysOfWeek)
                    })
                .Page(page)
                .ToList();
