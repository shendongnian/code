    // alias for later use
    ProjectCharter project = null;
    ProjectCharterTemplate template = null;
    var list = session
        .QueryOver<ProjectCharter>(() => project)
        // the JOIN will replace the WHERE in the CROSS JOIN above
        // it will be injected by NHibernate based on the mapping
        // relation project has many-to-one template
        .JoinQueryOver<ProjectCharterTemplate>(c => c.Templates, () => template)
        .Select(
            // select some project properties
            _ => project.ContentEnglish,
            ...
            // select some template properties
            _ => template.DescriptionEnglish,
         )
        .List<object[]>();
