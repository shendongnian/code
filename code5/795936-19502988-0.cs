    var  workItemAssignments = workItemQuery.ToArray() // .ToArray() will enumerate results of query
        .Select(o => new WorkItemAssignment()
                {
                    EndDate = o.EndDate,
                    StartDate = o.StartDate,
                    IsExternal = "N/A",
                    ResourceAssignedName = "N/A",
                    RoleName = "N/A",
                    RoleProficiency = "N/A",
                    Specialties = Enumerable.Empty<string>().AsQueryable(), //DO NOT WORK !!!
                    WorkItemName = o.Name,
                    WorkItemOwner = o.OwnerResource.FirstName + " " + o.OwnerResource.LastName,
                    WorkItemStatus = o.WorkItemStatus.Name,
                    Days = null,
                    Percentage = null,
                    RequestId = null
                });
