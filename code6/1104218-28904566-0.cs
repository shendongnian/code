    var topIssues = (from issue in list
                    group issue by new {issue.Category, issue.Issue}
                    into issueGroup
                    select new
                    {
                        Issue = issueGroup.Key, 
                        Count = issueGroup.Count(),
                        GP = (from i in issueGroup group i by i.Product into gp select new
                        {
                            Product = gp.Key, Count = gp.Count()
                        }).OrderByDescending(g=>g.Count)
                    }).OrderByDescending(d=>d.Count);
