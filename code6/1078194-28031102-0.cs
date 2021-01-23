    public void Function1(string inputfile, CancellationToken token, IProgress<double> progress)
    {
      ...
          pendingTime = timePerIteration * (Iterations - IterationCounter);
          Times[IterationCounter] = string.Format("{0:0} s", pendingTime / 1000);
          if (progress != null)
            progress.Report(pendingTime);
      ...
    }
