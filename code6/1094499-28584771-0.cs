    public bool IsOvertimeEligible
    {
        get
        {
            return this.PayType == PayType.Hourly;
        }
    }
