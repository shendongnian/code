           var results =
                from college in db.Colleges
                join student in db.StudentInfo on college.Id equals student.UniversityId
                where model.SelectedTerms.Contains(student.TermOfInterestId.Value) &&
                      model.SelectedPrograms.Contains(student.ProgramId.Value) &&
                      model.SelectedStatuses.Contains(student.Status)
                group college by new
                {
                    College = college.Name,
                    Accepts = (
                     from c1 in db.Colleges
                     join s1 in db.StudentInfo on c1.Id equals s1.UniversityId
                     where model.SelectedTerms.Contains(s1.TermOfInterestId.Value) &&
                           model.SelectedPrograms.Contains(s1.ProgramId.Value) &&
                           model.SelectedStatuses.Contains(s1.Status) &&
                           s1.UniversityId == college.Id &&
                           s1.Status.ToLower().Contains("accepted") || s1.Status.ToLower().Contains("applicant")
                     select c1
                    ).Count(),
                    Webapps = (
                        from c2 in db.Colleges
                        join s2 in db.StudentInfo on c2.Id equals s2.UniversityId
                        where model.SelectedTerms.Contains(s2.TermOfInterestId.Value) &&
                              model.SelectedPrograms.Contains(s2.ProgramId.Value) &&
                              model.SelectedStatuses.Contains(s2.Status) &&
                              s2.UniversityId == college.Id &&
                              s2.Status.ToLower().Contains("webapp")
                        select c2
                    ).Count(),
                    Ays = (
                        from c3 in db.Colleges
                        join s3 in db.StudentInfo on c3.Id equals s3.UniversityId
                        where model.SelectedTerms.Contains(s3.TermOfInterestId.Value) &&
                              model.SelectedPrograms.Contains(s3.ProgramId.Value) &&
                              model.SelectedStatuses.Contains(s3.Status) &&
                              s3.UniversityId == college.Id &&
                              !s3.Status.ToLower().Contains("accepted") && !s3.Status.ToLower().Contains("applicant") &&
                              !s3.Status.ToLower().Contains("webapp")
                        select c3
                    ).Count()
                }
                    into grouping
                    select new EnrollmentCountsBySchoolResult
                    {
                        College = grouping.Key.College,
                        Accepts = grouping.Key.Accepts,
                        Webapps = grouping.Key.Webapps,
                        Ays = grouping.Key.Ays,
                        Total = grouping.Count()
                    };
            model.Results = results.OrderByDescending(o => o.Total).ToList();
