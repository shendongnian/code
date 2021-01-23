    Status e = Status.Enabled;
    Status f = Status.Disabled;
    if (e || f.IsDisabled)
    {
        // ...
    }
    // Alternatively:
    if ((e == Status.Enabled) || (f == Status.Disabled))
    {
        // ...
    }
