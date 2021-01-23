    private static IList<ApplicationNames> ApplicationNamesSync {
        get {
            // Use the same synchronization that prevents concurrent modifications
            lock (appNamesLock) {
                return applicationNames.ToList(); // Make a copy
            }
        }
    }
