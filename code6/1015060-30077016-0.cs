    string _versionDB = "1.0.0.0"
    
    var version = new Version(_versionDB);
    // Increment Major version
    var newMajorVersion = new Version(version.Major+1,version.Minor,version.Build,version.Revision);
    // Increment Minor version
    var newMinorVersion = new Version(version.Major,version.Minor+1,version.Build,version.Revision);
    // Increment Build version
    var newBuildVersion = new Version(version.Major,version.Minor,version.Build+1,version.Revision);
    // Increment Revision
    var newRevisionVersion = new Version(version.Major,version.Minor,version.Build,version.Revision+1);
