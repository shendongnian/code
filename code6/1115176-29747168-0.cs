    List<IChangesetSummary> changeSets = InformationNodeConverters.GetAssociatedChangesets(build);
    IEnumerable<Change> changes = changeSets.SelectMany(x => versionControlServer.GetChangesForChangeset(x.ChangesetId, false, Int32.MaxValue, null, null, true));
        
    foreach (Change change in changes)
    {
        if ((change.ChangeType & ChangeType.Merge) == 0) continue;                  
        foreach (var m in change.MergeSources)
        {
            // ...
        }
    }
