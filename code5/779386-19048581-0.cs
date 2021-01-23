    versionControlService.QueryHistory(
                path, 
                VersionSpec.Latest,
                0,
                RecursionType.Full, //look into all subfolders
                null,
                VersionSpec.ParseSingleSpec("C1", null), //version from
                VersionSpec.Latest, //version to - all
                1, //Return at maximum 1 item
                boolIncludeChanges, // Include information on changes done
                false,
                boolIncludeDLInfo,
                true //sort ascending - C1, C2, .. CLatest
    )
