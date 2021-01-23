    internal static void Save(this List<Issue> issues)
    {
        using (var db = new Context())
        {
            foreach (var issue in issues.ToList())
            {
                foreach (var workItem in issue.WorkItems.ToList())
                {
                    if (workItem.Author != null)
                    {
                        var existing = db.Users.SingleOrDefault(e => e.Login == workItem.Author.Login);
                        if (existing == null)
                        {
                            db.Users.Add(workItem.Author);
                        }
                        else
                        {
                            //Update existing entities' properties
                            existing.Url = workItem.Author.Url;
                            //Replace reference
                            workItem.Author = existing;
                        }
                        db.SaveChanges();
                    }
                    var existingWorkItem = db.WorkItems.SingleOrDefault(e => e.Id == workItem.Id);
                    if (existingWorkItem == null)
                    {
                        db.WorkItems.Add(workItem);
                    }
                    else
                    {
                        //Update existing entities' properties
                        existingWorkItem.Duration = workItem.Duration;
                        //Replace reference
                        issue.WorkItems.Remove(workItem);
                        issue.WorkItems.Add(existingWorkItem);
                    }
                    db.SaveChanges();
                }
                var existingIssue = db.Issues.SingleOrDefault(x => x.Id == issue.Id);
                if (existingIssue == null)
                {
                    db.Issues.Add(issue);
                }
                else
                {
                    //Update existing entities' properties
                    existingIssue.SpentTime = issue.SpentTime;
                }
                db.SaveChanges();
            }
        }
    }
