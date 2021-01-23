    string selectedEmp=parameter.selectedEmp;
    IEnumerable<DatatablesViewModel> viewmodel = 
         (from a in db.tHREmployees
          join b in db.tTADTRs on a.EmpID equals b.EmpID
          join c in db.tHRJobGrades on a.JobGrdID equals c.JobGrdID
          join d in db.tTAShifts on b.ShftID equals d.ShftID
          join e in db.tTADays on b.DayID equals e.DayID
          where (b.LogDt >= PeriodDates.FromDt && b.LogDt <= PeriodDates.ToDt) &&
          (selectedEmp != "ALL" || a.EmpID == param.CustomParam_EmpID)
     select new DatatablesViewModel
          {
               ...
          }
