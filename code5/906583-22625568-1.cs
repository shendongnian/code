     dbContext.AtdDailyAttendances.Join(dbContext.AcAdmissionSessionDetails, m => m.StudentLedgerId,      n => n.StudentLedgerId, (m, n) => new{ 
                                    m.AcdAdmissionSessionDetails,
                                    m.DateId,
                                    m.StudentLedgerId,
                                    m.SchoolId,
                                    m.UserId,
                                    AttendanceSessionId = n.SessionId,
                                    AdmissionSessionId = m.SessionId,
                                    n.ClassId,
                                    n.SectionId,
                                    n.MediumId,
                                    n.StreamId
      }).Where(n => n.AttendanceSessionId == n.AdmissionSessionId).ToList();
