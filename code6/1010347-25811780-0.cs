    public double GetResult(List<int> values)
    {
        int median = Median(values);
        return values.Where(x => Math.Abs(x - median) < 10 * median).Average();
    }
    public static int Median(IEnumerable<int> list)
    {
        List<int> orderedList = list
          .OrderBy(numbers => numbers)
          .ToList();
        int listSize = orderedList.Count;
        int result;
        if (listSize % 2 == 0) // even
        {
            int midIndex = listSize / 2;
            result = ((orderedList.ElementAt(midIndex - 1) +
                   orderedList.ElementAt(midIndex)) / 2);
        }
        else // odd
        {
            double element = (double)listSize / 2;
            element = Math.Round(element, MidpointRounding.AwayFromZero);
            result = orderedList.ElementAt((int)(element - 1));
        }
        return result;
    }
