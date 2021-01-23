    var changes = vcs.QueryHistory(
        path, 
        VersionSpec.Latest, 
        0, 
        RecursionType.Full, 
        null, 
        VersionSpec.ParseSingleSpec("C100", null), // starting from changeset 100
        VersionSpec.ParseSingleSpec("C200", null), // ending with changeset 200
        int.MaxValue, 
        true, 
        false);
     foreach(Changeset change in changes)
     {
         Console.WriteLine("{0} {1}", change.ChangesetId, change.Comment);
     }
