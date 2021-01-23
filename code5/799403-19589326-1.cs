    private static TimeSpan calcAverageTimeUid2(ISomeObject someObj, int N, ISnapshot _Snapshot)
    { 
        var stopWatch = new Stopwatch();
        var prop = someObj.Uid;
        stopWatch.Start();
        var obj = _Snapshot.GetObject(prop);
        stopWatch.Stop();
        return stopWatch.Elapsed;
    }
