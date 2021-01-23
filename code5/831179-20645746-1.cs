    private void LogGCState() {
        int gen = GC.GetGeneration(this);
        //------------------------------------------
        // Comment out the GC.GetTotalMemory(true) line to see what's happening 
        // without any interference
        //------------------------------------------
        StringBuilder sb = new StringBuilder();
        sb.Append(DateTime.Now.ToString("G")).Append('\t');
        sb.Append("MaxGens: ").Append(GC.MaxGeneration).Append('\t');
        sb.Append("CurGen: ").Append(gen).Append('\t');
        sb.Append("CurGenCount: ").Append(GC.CollectionCount(gen)).Append('\t');
        sb.Append("TotalMemory: ").Append(GC.GetTotalMemory(false)).Append('\t');
        sb.Append("AfterCollect: ").Append(GC.GetTotalMemory(true)).Append("\r\n");
        File.AppendAllText(@"C:\GCLog.txt", sb.ToString());
    }
