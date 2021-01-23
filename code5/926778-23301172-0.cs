    // First, get the globally unique message id(s) for the message(s).
    var summaries = folder.Fetch (uids, MessageSummaryItems.GMailMessageId);
    // Next, mark them for deletion...
    folder.AddFlags (uids, MessageFlags.Deleted, true);
    // At this point, the messages have been moved to the Trash folder.
    // So open the Trash folder...
    folder = client.GetFolder (SpecialFolder.Trash);
    folder.Open (FolderAccess.ReadWrite);
    // Build a search query for the messages that we just deleted...
    SearchQuery query = null;
    foreach (var message in summaries) {
        var id = SearchQuery.GMailMessageId (message.GMailMessageId);
        query = query != null ? query.Or (id) : id;
    }
    // Search the Trash folder for these messages...
    var matches = folder.Search (query);
    // Not sure if you need to mark them for deletion again...
    folder.AddFlags (matches, MessageFlags.Deleted, true);
    // Now purge them from the Trash folder...
    folder.Expunge (matches);
