    private void Compute(CancellationToken ct)
    {
        while (true)
        {
           ComputeNextStep();
           ct.ThrowIfCancellationRequested();
        }
    }
