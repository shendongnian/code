    var clubAttendeeEducationList = (from oer in db.OnlineEducationRegistrations
                                    /* rest of the query */
                                    select new ClubAttendeeEducation
                                    {
                                        Session = item.CourseTitle,
                                        Date = item.OnlineEducationRegistration.DateCompleted.Value
                                    }).ToList();
