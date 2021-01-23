    public void LoadAllEditForms()
    {
        Assembly project = Assembly.Load("UnionAdministrator");
        var formsList = project.GetTypes()
            .Where (t => t.BaseType == typeof(BaseEditForm) && t.Name.EndsWith("EditForm"))
            .ToList();
    }
