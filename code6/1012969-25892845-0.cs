    // Initially, we make a group of all the issue attachments based on the IssueID
    // and we count the corresponding number of attachments.
    var attachments = db.IssueAttachments
                        .GroupBy(x=>x.IssueID)
                        .Select(x=> new { IssueID = x.Key, 
                                          NumberOfAttachments = x.Count()
                        });
