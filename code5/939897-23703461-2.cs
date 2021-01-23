    public static Expression<Func<Project, ProjectModel>> FullSelector =
        AddressModel.FullSelector.Use((Project project,
            Func<Address, AddressModel> selector) => new ProjectModel
            {
                ProjectName = project.ProjectName,
                ProjectNumber = project.ProjectNumber,
                Addresses = project.Addresses.Select(selector),
            });
