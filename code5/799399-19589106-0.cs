        for (int i = 0; i < N; i++)
        {
            stopWatch.Restart();  // Restart rather than Start
            var coll = _Snapshot.GetObject(uid);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            averageTime = averageTime + ts.Milliseconds;
        }
        averageTime = averageTime / N;
