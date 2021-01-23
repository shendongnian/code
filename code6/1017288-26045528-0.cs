    var r = (from oer in db.OnlineEducationRegistrations
             join oec in db.OnlineEducationCourses on oer.OnlineEducationCourseId equals
             oec.OnlineEducationCourseId
             where oer.District == districtId && 
                   oer.DateCompleted >= start && 
                   oer.DateCompleted <= end
             group new {oer, oec} by new {oec.CourseTitle, oec.OnlineEducationCourseId} into g
             select new {g.OnlineEducationCourseId, g.CourseTitle, CourseCount = g.Count() }).ToList();
        foreach (var item in r)
        {
            var courseId = item.OnlineEducationCourseId;
            var courseTitle = item.CourseTitle;
            var courseCount = item.CourseCount;
        }
