    public IEnumerable<int> GetQuery(int count)
    {
        var query = Enumerable.Range(0, count / 4 * 1440)
            .Select(
                (n, index) =>
                {
                    var workingIndex = index % 1440;
                    if ((workingIndex >= 480 && workingIndex < 750) 
                            || (workingIndex >= 810 && workingIndex < 1080))
                        return 0;
                    else if (workingIndex >= 750 && workingIndex < 810)
                        return 1;
                    else
                        return 2;
                });
        return query.ToArray();
    }
