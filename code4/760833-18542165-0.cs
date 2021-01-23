    courses = courses.Where(
                c => (queryParameters.ShowInActive || c.Flags.Contains((ulong)CourseFlags.Active))
                     &&
                     (queryParameters.AuthorId <= 0 ||
                      (c.Authors != null && c.Authors.Exists(a => a.ID == queryParameters.AuthorId)))
                     &&
                     ((queryParameters.CategoryIDs == null || queryParameters.CategoryIDs.Count == 0 ||
                      (c.Tags != null && c.Tags.Any(t => queryParameters.CategoryIDs.Contains(t.ID))))
                      &&
                      (queryParameters.CourseIDs == null || queryParameters.CourseIDs.Count == 0 ||
                      queryParameters.CourseIDs.Contains(c.ID)))
                ).ToList();
