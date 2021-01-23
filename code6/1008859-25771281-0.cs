      var activities = from a in Session.Context.Activities
                  join at in Session.Context.ActivityTypes
                    on a.ActivityTypeID equals at.ActivityTypeID
                  join u in Session.Context.Users
                    on a.CreatedByUserID equals u.UserID
                  where a.IssueID == issueId
                  select new ActivityGridModel()
                  {
                      ActivityDate = a.ActivityDate,
                      ActivityType = at.ActivityType1,
                      Notes = a.Notes,
                      EnteredBy = u.FirstName + " " + u.LastName,
                      TimeSpent = a.TimeSpent,
                      Days = a.TimeSpent.Days,
                      Hours = a.TimeSpent.Hours,
                      Minutes = a.TimeSpent.Minutes
                  };
