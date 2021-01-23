    var result = records.Aggregate(
        Tuple.Create(default(List<Record>), new List<List<Record>>()),
        (acc, record) =>
        {
            var grouping = acc.Item1;
            var result = acc.Item2;
            if (grouping == null && record.Type == "a")
            {
                grouping = new List<Record>();
            }
            if (grouping != null)
            {
                grouping.Add(record);
                if (record.Type == "b")
                {
                    result.Add(grouping);
                    grouping = null;
                }
            }
            return Tuple.Create(grouping, result);
        },
        acc => acc.Item2
    );
