    int[] values = Enum.GetValues(typeof(TimePeriodsToTest))
        .Cast<int>()
        .OrderBy(x => x)
        .ToArray();
    for (int k = 0; k < values.Length; k++)
    {
        sinceDateTime = DateTime.Now.AddDays(values[k]);
        fileCount = ....
        counter.TimePeriodCount[k] = fileCount;
    }
