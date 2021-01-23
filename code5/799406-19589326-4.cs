    private static void mainCalc(ISomeObject someObj, int N, ISnapshot _Snapshot)
    {
        var averageTimeUID = TimeSpan.Zero;
        for (int i = 0; i < N; i++)
        {
            averageTimeUID += calcAverageTimeUid2(someObj,N,_Snapshot);
        }
        averageTimeUID = new TimeSpan( averageTimeUID.Ticks / N );
    }
