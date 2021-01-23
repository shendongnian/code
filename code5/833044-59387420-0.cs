    var stopWatch = new Stopwatch();
            stopWatch.Start();
            for (var i = 0; i < 10; ++i)
            {
                CallGetHttpClient();
                CallPostHttpClient();
            }
            stopWatch.Stop();
            var httpClientValue = stopWatch.Elapsed;
            stopWatch = new Stopwatch();
            stopWatch.Start();
            for (var i = 0; i < 10; ++i)
            {
                CallGetWebRequest();
                CallPostWebRequest();
            }
            stopWatch.Stop();
            var webRequesttValue = stopWatch.Elapsed;
            stopWatch = new Stopwatch();
            stopWatch.Start();
            for (var i = 0; i < 10; ++i)
            {
                CallGetWebClient();
                CallPostWebClient();
            }
            stopWatch.Stop();
            var webClientValue = stopWatch.Elapsed;
