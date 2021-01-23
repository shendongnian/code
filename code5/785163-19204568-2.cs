    private static readonly Dictionary<int, FaultType> FaultTypeDictionary =
        Enum.GetValues(typeof(FaultType))
            .Cast<FaultType>()
            .ToDictionary(
                x => (int)typeof(FaultTypeConstants).GetField(x.ToString()).GetValue(null),
                x => x);
    public static List<FaultType> GetFaults(List<int> faults)
    {
        return faults.Select(x => FaultTypeDictionary[x]).ToList();
    }
