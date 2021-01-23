    [NotMapped]
    public virtual SeverityStatus SeverityStatus
    {
        get
        {
            // Implement your calculation logic here
            if (ProbableStatusId == 1 && SeverityStatusId == 1)
                return new SeverityStatus();
            // ...
        }
    }
