    select 
        Applications.ApplicationName, 
        Projects.ProjectName 
    from ImpactedApplications 
    inner join  Applications 
        on ImpactedApplications.AppId=Applications.AppId
    inner join Projects 
        on ImpactedApplications.ProjectId=Projects.ProjectId
    where Projects.ProjectId=@projectId
