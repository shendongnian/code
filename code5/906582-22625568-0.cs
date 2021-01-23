     dbContext.AtdDailyAttendances.Join(dbContext.AcAdmissionSessionDetails, m => m.StudentLedgerId,      n => n.StudentLedgerId, (m, n) => new{ 
                                    m.AcdAdmissionSessionDetails,
                                    m.DateId,
                                    m.StudentLedgerId,
                                    m.SchoolId,
                                    m.UserId,
                                    n.SessionId,
                                    n.ClassId,
                                    n.SectionId,
                                    n.MediumId,
                                    n.StreamId
      }).ToList();
