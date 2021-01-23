    public void ListBoxProjectTypes()
    {
        IEnumerable<ProjectType> projectTypes = projectTypeRepository.ProjectTypes;
        ListBoxProjectType.Items.AddRange(projectTypes.Select(item => (object)item.Title).ToArray());
    }
