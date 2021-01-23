    [__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries"), SecuritySafeCritical]
    public string ToString(IFormatProvider provider)
    {
        return Number.FormatInt32(this, null, NumberFormatInfo.GetInstance(provider));
    }
