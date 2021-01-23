    var obj = new
    {
        States = new[] { new{ State = "MX" } },
        Zip = "",
        Miles = "",
        PaginationStart = 1,
        PaginationLimit = 3
    };
    string data = JsonConvert.SerializeObject(obj);
