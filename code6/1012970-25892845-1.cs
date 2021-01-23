    // Later we join the Issues tables rows with attachments results based on the IssueID
    // and we select the corresponding data
    var issues = from i in db.Issues
                 join a in attachments
                 on i.IssueID equals a.IssueID
                 select new IssueModel
                 {
                     IssueID = i.IssueID,
                     /*** more fields ***/
                     NumberOfAttachments = a.NumberOfAttachments
                 };
