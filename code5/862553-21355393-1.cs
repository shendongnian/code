    public static IEnumerable<MileageRecord> Load()
    {
        return File.ReadAllLines("\path")
                   //.Skip(1) // if first line of the file is column headers
                   .Select(line => line.Split(new char[] { ',' }))
                   .Where(data => data.Length == 8)
                   .Select(data => MileageRecord.FromCSV(data))
                   .Where(mileage => mileage != null);
    }
