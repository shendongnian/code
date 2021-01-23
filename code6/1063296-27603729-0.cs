    public static class DataCollectorExtensions
        {
            public static InfoData<ExtraInfo> AddInfoData(this DataCollector dataCollector, InfoData<ExtraInfo> data)
            {
                return dataCollector.Add<InfoData<ExtraInfo>, ExtraInfo>(data);
            }
        }
