    public Expression<Func<EventGym, bool>> GetGym(string applicationId)
    {
        return q => q.Event.Active && q.Event.Visible && q.Event.MobileEventApplications.Any(m =>
                              m.MobileApplication.ApplicationId == applicationId &&
                              (!m.MobileApplication.ActivationLength.HasValue || DbFunctions.AddDays(DateTime.Now, 1) < DbFunctions.AddMonths(m.MobileApplication.DateActivated, m.MobileApplication.ActivationLength.Value)));
    }
