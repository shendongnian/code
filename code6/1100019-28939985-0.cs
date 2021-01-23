     public static bool DirectorySynchronisation(string sourceFiles, string targetFiles)
        {
            Trace.Info("Beginning Directory Sync");
            try
            {
                Trace.Info("... between source location: {0} and targeted location: {1}", sourceFiles, targetFiles);
                //Exclude metadata from sync.
                var fileSyncScopeFilter = new FileSyncScopeFilter();
                fileSyncScopeFilter.FileNameExcludes.Add("metadata.abc");
                // Create file system provider
                var source = new FileSyncProvider(Guid.NewGuid(), sourceFiles, fileSyncScopeFilter, FileSyncOptions.None);
                var target = new FileSyncProvider(Guid.NewGuid(), targetFiles);
                // Ask providers to detect changes
                source.DetectChanges();
                target.DetectChanges();
                // Sync changes
                SyncOrchestrator agent = new SyncOrchestrator
                {
                    LocalProvider = source,
                    RemoteProvider = target,
                    Direction = SyncDirectionOrder.Upload //One way only
                };
                agent.Synchronize();
                Trace.Info("Completed Directory Sync");
                return true;
            }
            catch (Exception exception)
            {
                Trace.Info("Exception thrown while syncing files");
                Trace.Exception(exception);
                return false;
            }
        }
