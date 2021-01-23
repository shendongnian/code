    int nr = 0;
    foreach (var item in lists.Select(x => x.match_id))
    {
        foreach (var match in lists)
        {
            var n = match.nickname
                .Where(x => lists[nr].match_id == match.match_id)
                .Select(z => match.nickname)
                .FirstOrDefault();
            if (n != null)
            {
                Console.Write(n);
            }
        }
        nr++;
    }
