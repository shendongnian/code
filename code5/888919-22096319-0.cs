    var scholars = db.Scholars.Join(db.Suspensions,
            scholar => scholar.ID,
            suspension => suspension.ScholarID,
            (scholar, suspension) => new {scholar, suspension})
        .Where(u => u.suspension.StartDate >= startDate && 
                    u.suspension.EndDate <= endDate)
        .GroupBy(u => new { u.scholar.ID, u.scholar.FirstName, u.scholar.LastName })
        .Select(u => new 
            {
                FullName = u.Key.FirstName + " " + u.Key.LastName,
                TotalSuspensionSum = u.Sum(x => 
                    x.scholar.Suspensions.Sum(y => y.SuspensionDays)
                )
            })
        .OrderBy(x => x.FullName)
        .ToList();
        
