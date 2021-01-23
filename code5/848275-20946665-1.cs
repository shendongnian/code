    [__DynamicallyInvokable]
    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    void IProgress<T>.Report(T value)
    {
      this.OnReport(value);
    }
