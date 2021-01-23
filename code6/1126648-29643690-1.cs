    var query = db.From<ProjectTask>()
                  .Join<ProjectTask, Project>((pt, p) => pt.ProjectId == p.ProjectId)
                  .Where<Project>(p => p.DepartmentId == departmentId || departmentId == 0)
                  .And<ProjectTask>(pt => pt.ProjectTaskStatusId == statusId || statusId == 0);
    var tasks = await dbCon.SelectAsync<ProjectTask>(query);
