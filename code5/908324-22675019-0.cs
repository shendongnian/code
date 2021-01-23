    ListBoxProjectType.BeginUpdate();
    foreach( var projectType in projectTypes )
    {
        ListBoxProjectType.Items.Add(projectType.Title);
    }
    ListBoxProjectType.EndUpdate();
