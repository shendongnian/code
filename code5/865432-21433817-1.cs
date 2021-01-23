    public static IEnumerable<Meter> LoadMeterListFromFile()
    {
        foreach (var line in File.ReadAllLines(@"C:\MyLog.Log"))
        {
            var columns = line.Split(';');
            yield return new Meter
                {
                    TimeStamp = columns[0],
                    MeterUID = columns[1],
                    Something1 = Convert.ToInt32(columns[2].Replace("Something1=", "")),
                    Something2 = Convert.ToInt32(columns[3].Replace("Something2=", "")),
                    Something3 = Convert.ToInt32(columns[4].Replace("Something3=", "")),
                    Something4 = Convert.ToInt32(columns[5].Replace("Something4=", "")),
                    Something5 = Convert.ToInt32(columns[6].Replace("Something5=", ""))
                };
        }
    } 
