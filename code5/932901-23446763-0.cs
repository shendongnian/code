    // 1. Find the Unique itemIDs to remove
    var idsToRemove = emails.Select("failEmail = 'fail'").Select (x => x["itemID"]).Distinct();
    // 2. Find all the rows that match the itemIDs found
    var rowsToRemove = emails.Select(string.Format("itemID in ({0})", string.Join(", ", idsToRemove)));
    // 3. Remove the found rows.
    foreach(var rowToRemove in rowsToRemove)
    {
    	emails.Rows.Remove(rowToRemove);
    }
    emails.AcceptChanges();
