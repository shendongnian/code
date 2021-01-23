    double GetAverage(List<double> doublesList)
    {
        var list = doublesList.Where(x => x != null).ToList();
        return list.Average();
    }
