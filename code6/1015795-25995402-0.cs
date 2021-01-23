        private void NotifyFileSystemEventArgs(int action, string name)
        {
            if (this.MatchPattern(name))
            {
                switch (action)
                {
                    case 1:
                        this.OnCreated(new FileSystemEventArgs(WatcherChangeTypes.Created, this.directory, name));
                        return;
                    
                    case 2:
                        this.OnDeleted(new FileSystemEventArgs(WatcherChangeTypes.Deleted, this.directory, name));
                        return;
                    
                    case 3:
                        this.OnChanged(new FileSystemEventArgs(WatcherChangeTypes.Changed, this.directory, name));
                        return;
                }
            }
        }
