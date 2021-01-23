    public static void AddBollingerBands(ref SortedList<DateTime, Dictionary<string, double>> data, int period, int factor)
    {
        var moving_avg = new MovingAverageCalculator(period);
        for (int i = 0; i < data.Count(); i++)
        {
            moving_avg.AddObservation(data.Values[i]["close"]);
            if (moving_avg.HasFullPeriod)
            {
                var average = moving_avg.Average;
                var limit = factor * moving_avg.StandardDeviation;
                data.Values[i]["bollinger_average"] = average;
                data.Values[i]["bollinger_top"] = average + limit;
                data.Values[i]["bollinger_bottom"] = average - limit;
            }
        }
    }
