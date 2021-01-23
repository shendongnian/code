    public MainWindowViewModel()
    {
        this.InstalledVersions = InstalledVersionViewModel.GetInstalledVersions();
        foreach (var version in this.InstalledVersions)
        {
            version.PropertyChanged += this.VersionPropertyChanged;
        }
    }
