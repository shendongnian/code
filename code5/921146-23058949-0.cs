    public IEnumerable<int> GetQuery(int count)
    {
        var query = Enumerable.Range(0, count / 4 * 1440)
            .Select(
                (n, index) =>
                {
                    if ((index >= 480 && index < 750) || (index >= 810 && index < 1080))
                        return 0;
                    else if (index >= 750 && index < 810)
                        return 1;
                    else
                        return 2;
                });
        return query.ToArray();
    }
