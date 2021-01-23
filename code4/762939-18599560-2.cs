    if(!String.IsNullOrEmpty(ddlProjTemplates.SelectedValue))
    {
        // Now you know there is some value to attempt to convert
        EzProject templateProject = DBAccessProjects.GetProject(tenantID, new Guid(ddlProjTemplates.SelectedValue));
    }
