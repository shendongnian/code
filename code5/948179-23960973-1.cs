    object True = -1;
    foreach (var entry in YourCollectionOfEntries)
    {
        var bmkRange = Globals.ThisDocument.bmkStart.Range;
        object newRangeStart = bmkRange.End;
        bmkRange.InsertAfter(entry);
        bmkRange.Select();
        bmkRange = Globals.ThisDocument.Bookmarks.Add(Globals.ThisDocument.bmkStart.Name, Selection.Range);
        object newRangeEnd = bmkRange.End; 
        var newRange = Globals.ThisDocument.Range(ref newRangeStart, ref newRangeEnd);
        if (isBoldForThisEntry)
            newRange.Bold = True;
    }
