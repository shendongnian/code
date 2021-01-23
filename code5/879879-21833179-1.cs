    public static void LoadMeterListFromFile(List<FileInfo> fileList)
    {
        foreach (FileInfo fi in fileList)
        {
            foreach (var line in File.ReadAllLines(fi.FullName))
            {
                var columns = line.Split(';');
                string meterID= columns[1];
                if (!meters.ContainsKey(MeterID))
                {
                    meters.Add(meterID, new Meter() { MeterID = meterID, data = new List<Data>() });
                }
                Data d = new Data
                {
                    MeterID = meterID,
                    TimeStamp = columns[0],
                    Signal = Convert.ToInt32(columns[2].Replace("SignalStrength=", ""))
                };
                meters[MeterID].data.Add(d);
            }
        }
    }
