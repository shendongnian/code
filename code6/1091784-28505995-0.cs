    public Project Project
    {
        get { return project; }
        set {
            if (project != null) project.PropertyChanged -= ChildPropertyChanged;
            project = value;
            RaisePropertyChanged("Project");
            if (project != null) project.PropertyChanged += ChildPropertyChanged;
        }
    }
