    Status e = Status.Enabled;
    Status f = Status.Disabled;
    if (e || f.IsDisabled)
    {
        // ...
    }
    // Alternatively:
    if ( e.Equals(Status.Enabled) || f.Equals(Status.Disabled) )
    {
        // ...
    }
