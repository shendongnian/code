    var gridInfo = (from teacher in TeacherAccesses
                    join u in USERS
                    on teacher.ID equals u.ID
                    where teacher.Year = TeacherAccesses.Where(x => x.ID = teacher.ID)
                                             .Max(x => x.TeacherAttr.SchoolEndYear)
                    select new 
                    {
                       Name = u.LastName + ", " + u.FirstName,
                       ID = teacher.ID,
                       Flag = "Existing",
                       SchoolID = teacher.SchoolID,
                       status = teacher.TeacherAttr.IncludeinOfficialResults.Value,
                       SchoolEndYear = teacher.TeacherAttr.SchoolEndYear
                     });
