    var query = from pmt in db.ProjectHasTags
                join project in db.Projects on pmt.ProjectId equals project.ID
                join tag in db.ProjectTags
                     on pmt.TagId equals tag.ID
                     group pmt by pmt.Project into pmtGroup
                        select new ProjectHasTag
                        {
                            Project = pmtGroup.Key,
                            Tags = pmtGroup.Select(project => project.ProjectTag)
                        };
