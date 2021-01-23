    using System.Data.Entity;
    // ....
    var schedules = db.Schedules.Include(s => s.Movie)
                        .OrderByDescending(s => s.Movie.MovieName)
                        .ToList();
    return View(schedules);
