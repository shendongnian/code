    public IEnumerable<string> TimeGet(List<string> heatList, TimeSpan startTimeSpan, TimeSpan timeGap)
    {
        foreach (var element in heatList)
        {
            var input = element.Substring(1); // Takes everything from index 1 = the first digit in the string
            int multiplier = Int32.Parse(input) - 1;
            var additionalTime = new TimeSpan(0, (int)(timeGap.Minutes * multiplier), 0);
            yield return (startTimeSpan + additionalTime).ToString();
        }
    }
