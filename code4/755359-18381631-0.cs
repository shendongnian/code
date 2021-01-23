    protected override int InternalAggregate(ref Exception singularExceptionToThrow)
    {
      using (IEnumerator<int> enumerator = this.GetEnumerator(new ParallelMergeOptions?    (ParallelMergeOptions.FullyBuffered), true))
      {
        int num = 0;
        while (enumerator.MoveNext())
          checked { num += enumerator.Current; }
        return num;
      }
    }
