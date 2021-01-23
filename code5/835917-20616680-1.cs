    var list = new int[] { 1, 2, 3, 4, 5 };
    var query = list.AsQueryable()
        .Where(n => n % 2 == 0)
        .Take(25);
    string querystring = query.ToString();
