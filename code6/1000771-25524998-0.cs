    var query = (from mc in context.SkillAssessCourseMains
                             join sc in context.SkillAssessCourseSubs.Where(x=>x.MainCourseRef!=null)
                             on mc.ID equals sc.MainCourseRef into results
                             from r in results.DefaultIfEmpty()
                             select new
                             {
                                 r.ID,
                                 mc.CourseName,
                                 r.SubCourseName
                             }).ToList();
