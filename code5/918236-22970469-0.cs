    int page = 1;         // the page you want to display, 1, 2, 3, ...
    int daysPerPage = 10;
    List<Blog> result = blogs
        .GroupBy(b => b.Created.Date)      // group blogs by day
        .OrderByDescending(g => g.Key)     // sort the day groups descending by day
        .Skip((page - 1) * daysPerPage)    // skip the pages before requested page
        .Take(daysPerPage)                 // take the next 10 day groups
        .SelectMany(g => g)                // get all blogs of 10 days in flat list
        .OrderByDescending(b => b.Created) // sort blogs descending by blog date+time
        .ToList();                         // make a list with the result
