    List<Schedule> model = obj.GetLessonlist();
    foreach (var t in model)
    {
        SchedulePresentation objpres=new SchedulePresentation();
        objpres.Capacity = t.Capacity;
        objpres.DateOfExam = objdateconverte.ConvertToPersianToShow(t.DateOfExame);
        objpres.className = objclassrep.FindClassById(t.ClassId).ClassName;
        objpres.degreeName = objdegreerep.FindDegreeById(t.DegreeId).DegreeName;
        objpres.examLocation = t.locationOfExame;
        objpres.facultyName = objfactulyrep.FindFacultyById(t.FacultyId).FacultyName;
        objpres.lessonName = objLessonRep.FindLessonById(t.LessonId).LessonName;
        objpres.majorName = objmajorrep.FindMajorById(t.MajorId).MajorName;
        objpres.semesterName = objsemesterrep.FindSemesterById(t.SemesterId).SemesterName;
        objpres.teacherName = objteacherrep.FindTeacherById(t.TeacherId).Name + " " +
                                      objteacherrep.FindTeacherById(t.TeacherId).LastName;
        list.Add(objpres);
    }
