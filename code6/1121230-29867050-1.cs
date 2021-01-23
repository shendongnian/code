           private int OptimizationTheDistributionOfTasks(int minDay, int maxDay, List<int> listDays, int day, List<int> holidays)
    {
        var listOfDays = new List<DaysForTaskPlan>();
        for (int k = minDay; k <= maxDay; k++)
        {
            var tempCountDays = listDays.Count(d => k == d);
            if (!holidays.Contains(k))
                listOfDays.Add(new DaysForTaskPlan(k, tempCountDays));
        }
        if (listOfDays.Any())
        {
            day = listOfDays.First(p => p.AmountDays == listOfDays.Min(z => z.AmountDays)).CurrDay;
        }
        listOfDays.Clear();
        return day;
    }
