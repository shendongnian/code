      var project = DbContext.Projects.Where(w => w.ProjectID > 0).Select(s =>
                        new CustomerProjectDDL()
                        {
                            ProjectName.ProjectID = s.ProjectID,
                            ProjectName.Name = s.Name
                        });
