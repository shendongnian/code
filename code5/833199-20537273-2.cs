       private long? lowestBreakIndex = null;
        private void StartProcess()
        {
            isPaused = IsTerminated = false;
            isProcessing = true;
            ParallelLoopResult result = Parallel.ForEach(
                items.Skip(lowestBreakIndex ?? 0) //I am assuming that items is some form of ICollection. The Skip function will skip to the next item to process
                , new ParallelOptions() { MaxDegreeOfParallelism = 4 }, (item, state) =>
                {
                    //I swapped these two.
                    if (isPaused) 
                        state.Break();
                    else if (IsTerminated) 
                        state.Stop();
                    else
                        item.Process();
                });
            lowestBreakIndex = result.LowestBreakIteration;
            isPaused = IsTerminated = false;
            isProcessing = false;
        }
