    public new void SuspendLayout()
    {
        base.SuspendLayout();
        ButtonLogger.AttachButtonLogging(this);
    }
