    public TimeSpan periodOfService
    {
        get
        {
            DateTime JoinDate;
            if (DateTime.TryParse(DateOfJoin, out JoinDate))
            {
                return DateTime.Now > JoinDate ? DateTime.Now - JoinDate : JoinDate - DateTime.Now;
            }
            return TimeSpan.Zero;
        }
    }
