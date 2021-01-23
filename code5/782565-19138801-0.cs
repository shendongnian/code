    private List<string> GetFiles(DateTime toDate, DateTime fromDate, string directoryName)
    {
        if (toDate > fromDate)
        {
            List<string> list = Directory.GetFiles(directoryName).ToList();
    
            return list.Where(f => File.GetCreationTime(f) <= toDate && File.GetCreationTime(f) => fromDate).ToList();
        }
        return new List<string>();
    }
