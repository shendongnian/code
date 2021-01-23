    public void CheckForWork() 
    {
        int original, replacement;
        do
        {
          original = _count;
          replacement = original < MAXIMUM ? original + 1 : original;
        }
        while (Interlocked.CompareExchange(ref _count, replacement, original) != original);
        if (replacement > original)
        {
          Task.Run(() => Work());
        }
    }
