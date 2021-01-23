    List<Children> todaysChildren = parents
        .SelectMany(p =>
        {
            switch(DateTime.Today.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return p.MondayChildren; 
                case DayOfWeek.Tuesday:
                    return p.TuesdayChildren; 
                // ...
                default: 
                    throw new NotSupportedException("Unsupported DayOfWeek");
            }
        })
        .ToList();
