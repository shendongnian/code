    using (dbOrganizationEntities1 myEntities = new dbOrganizationEntities1())
    {
        var allDepartments = (from tbProject in myEntities.tbProjects
                                // inner join to department lookup table
                                from refDepartments in myEntities.refDepartments.Where(x=>x.refDepartmentID == tbProject.refDepartmentID) // to do a left join instead of an inner, append .DefaultIfEmpty() after this where clause
                                // select new anon type
                                select new {
                                    refDepartmentID = tbProject.refDepartmentID,
                                    ProjectName = tbProject.ProjectName,
                                    refDepartmentValue = refDepartments.refDepartmentValue,
                                }).ToList(); // I chose to turn the result into a list to demonstrate something below, you can leave it as an enumerable.
        // you can access the properties of the anon type like so
        System.Diagnostics.Debug.Print(allDepartments[0].refDepartmentID);
        System.Diagnostics.Debug.Print(allDepartments[0].refDepartmentValue);
        // bind to your listview, make sure control name is accurate and ItemTemplates are defined for each data column.
        MyListView.DataSource = allDepartments;
        MyListView.DataBind();
    }
