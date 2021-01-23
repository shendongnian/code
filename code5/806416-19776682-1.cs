    public IEnumerable<Quality> Get(DateTime param1, DateTime param2, string param3)
        {     
            var dc = new VideoDataContext(WebApplication.MonitorServer);
            dc.CommandTimeout = 240;
            return dc.Vid_GetQualityForVideo(param1, param2, param3);
        }
