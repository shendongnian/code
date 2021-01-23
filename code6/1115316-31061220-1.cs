    client.Inbox.Open (FolderAccess.ReadOnly);
    var uids = client.Inbox.Search (SearchQuery.SubjectContains ("HELLO_"));
    if (uids.Count > 0) {
        var summaries = client.Inbox.Fetch (uids, MessageSummaryItems.Envelope);
        foreach (var summary in summaries) {
            if (summary.Envelope.Subject.StartsWith ("HELLO_"))
                return summary.Envelope.Subject;
        }
    }
