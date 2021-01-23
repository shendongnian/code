    public static ProjectModel FullSelector(Project project)
    {
        return new ProjectModel()
        {
            ProjectName = p.ProjectName,
            ProjectNumber = p.ProjectNumber
            Addresses = p.Addresses.Select(AddressModel.FullSelector);
        };
    }
