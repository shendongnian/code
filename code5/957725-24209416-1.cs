    private void VersionPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "IsActive")
        {
            var changedVersion = (Version)sender;
                    
            // Checks that the version has been activated
            if (changedVersion.IsActive)
            {
                // Finds the previously active version and archive it
                foreach (var version in this.InstalledVersions)
                {
                    if (version.IsActive && version != changedVersion)
                    {
                        version.Archive();
                    }
                }
            }
        }
    }
