    DateTime startDate = DateTime.Now.AddDays(-100); // {18/11/2014 4:04:07 PM}
    DateTime endDate = DateTime.Now; // {26/02/2015 4:04:07 PM}
    var query = Enumerable.Range(0, 1 + (endDate - startDate).Days)
        .Select(i => startDate.AddDays(i))
        .Where(r=> r.Day == 1);
