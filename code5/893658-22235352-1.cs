    var q = ses.Query<Task>()
               .Select(x => new 
               { 
                   Id = x.Id, 
                   CreatedDate = x.CreatedDate, 
                   Name = x.AssigneeGroup.Name, 
                   IsProcessGroup = x.AssigneeGroup.IsProcessGroup
               });
