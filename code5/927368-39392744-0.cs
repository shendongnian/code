    var result = projs.Select(p => new FoundProject
                    {
                        ProjectId = p.Id,
                        ProjectName = p.Name,
                        ProjectEntityTypeId = p.ProjectEntityTypeId,
                        ProjectEntityType = context.ProjectEntityTypes.Where(e => e.Id == p.ProjectEntityTypeId).Select(e => e.Name).FirstOrDefault(),
                        RentStatus = p.RentStatus,
                        RentPrice = p.RentPrice
                    });
