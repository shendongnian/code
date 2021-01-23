    Models.VisitDoctotDb oVisitdb = new Models.VisitDoctotDb();
    Models.RegVisit oReg_visit = new Models.RegVisit();
    oReg_visit.Patient = oPatient;
    oReg_visit.Visit = oVisit;
    oVisitdb.SaveChanges();
