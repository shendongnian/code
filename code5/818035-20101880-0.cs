    var result = from profile in db.PatientProfile.Include(p => p.Visit)
                 from visit in profile.Visits
                 select new
                        {
                            profile.PatientLastName,
                            visit.VisitId,
                            visit.VisitDate,
                            visit.EndVisitDate
                        };
