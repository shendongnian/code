    class Sponsor : MarshalByRefObject, ISponsor
    {
        public bool Release { get; set; }
        public TimeSpan Renewal(ILease lease)
        {
            // if any of these cases is true
            if (lease == null || lease.CurrentState != LeaseState.Renewing || Release)
                return TimeSpan.Zero; // don't renew
            return TimeSpan.FromSeconds(1); // renew for a second, or however long u want
        }
    }
