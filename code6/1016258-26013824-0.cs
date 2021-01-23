    int UserID = new BussinessComponent().LoginDetails.UserID;
    using (var db = new DataContext())
    {
        int? ContractorID =
              db
                  .Users
                  .Where(x => x.UserID == UserID)
                  .Select(x => x.ContractorID)
                  .Single();
        if (ContractorID.HasValue) // check for value, since it is nullable it can be null
          ltlOJ.Text = DashboardComponent.GetJobs(UserID, ContractorID.Value).ToString();
        else
          throw new MyReasonableExceptionToThrowHere(string.Format("Missing ContractorID for UserID '{0}'", UserID));
    }
