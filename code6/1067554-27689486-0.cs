    var prospectus = new [] 
    { 
        new { CourseId = "C1", CourseName = "Database" },
        new { CourseId = "C2", CourseName = "HCI" },
        new { CourseId = "C3", CourseName = "Op Systems" },
        new { CourseId = "C4", CourseName = "Programming" }
    };
    var enrollment = new []
    {
        new { TraineeID = "T1", CourseId = "C1", Date = new DateTime(2014, 12, 01) },
        new { TraineeID = "T2", CourseId = "C1", Date = new DateTime(2014, 12, 05) },
        new { TraineeID = "T1", CourseId = "C3", Date = new DateTime(2014, 12, 01) }
    };
    var notMatchingQueryStyle = from c in prospectus
                                where !enrollment.Any(r => c.CourseId == r.CourseId)
                                select c;
