    string json = JsonConvert.SerializeObject(new
    {
        Mexico_Schedule = new
        {
            States = new[] { new { State = "MX" } },
            Zip = "",
            Miles = "",
            PaginationStart = 1,
            PaginationLimit = 3
        }
    });
