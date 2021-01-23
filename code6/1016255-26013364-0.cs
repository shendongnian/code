    int UserID = new BussinessComponent().LoginDetails.UserID;
    using (var db = new DataContext())
    {
        int ContractorID =
              db
                  .Users
                  .Where(x => x.UserID == UserID)
                  .Select(x => x.ContractorID ?? 0)
                  .Single();
        ltlOJ.Text = DashboardComponent.GetJobs(UserID,ContractorID ).ToString();
