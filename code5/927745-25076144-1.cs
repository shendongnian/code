    public static void ChangeServiceStartupType(ServiceStartupType type, ...)
    {
        if (type == AutomaticDelayed)
        {
            if (ChangeServiceConfig2(.., DelayedAutoStart, ..))
            {
                ChangeServiceConfig(.., Automatic, ..);
            }
        }
        else
        {
            ChangeServiceConfig2(.., !DelayedAutoStart, ..)
            ChangeServiceConfig(.., type, ..)
        }
    }
