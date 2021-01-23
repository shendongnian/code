    List<TrainScheduleViewModel> viewModels = query
        .Select(t => new TrainScheduleViewModel
                    {
                        Id = t.Id,
                        ...
                        DaysOfWeek = BuildDaysOfWeek(t.DaysOfWeek)
                    })
                .Page(page)
                .Fetch(x => x.DaysOfWeek)
                .ToList();
