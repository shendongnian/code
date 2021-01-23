    private void GetAllCandidates(List<int> values)
    {
        Interlocked.Increment(ref _count);
        values.AsParallel().AsOrdered().ForAll((item) => 
        {
            // Do stuff
            GetAllCandidates(newPowers);
        }
    }
