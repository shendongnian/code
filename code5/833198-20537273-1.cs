       private long? lastProcessedIndex = null;
        private void StartProcess()
        {
            isPaused = IsTerminated = false;
            isProcessing = true;
            long startIndex = 0;
            if(lastProcessedIndex.HasValue)
                startIndex = lastProcessedIndex.Value + 1;
            ParallelLoopResult result = Parallel.ForEach(
                items.Skip(startIndex) //I am assuming that items is some form of ICollection. The Skip function will skip to the next item to process
                , new ParallelOptions() { MaxDegreeOfParallelism = 4 }, (item, state) =>
                {
                    //I swapped these two.
                    if (isPaused) state.Break();
                    if (IsTerminated) state.Stop();
                    item.Process();
                });
            lastProcessedIndex = result.LowestBreakIteration;
            isPaused = IsTerminated = false;
            isProcessing = false;
        }
