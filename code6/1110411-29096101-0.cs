    var relevantVMObjects = 
     (from a in db.tHREmployees
      join b in db.tTADTRs on a.EmpID equals b.EmpID
      join c in db.tHRJobGrades on a.JobGrdID equals c.JobGrdID
      join d in db.tTAShifts on b.ShftID equals d.ShftID
      join e in db.tTADays on b.DayID equals e.DayID
      where (b.LogDt >= PeriodDates.FromDt && b.LogDt <= PeriodDates.ToDt)
      select new DatatablesViewModel
      {
          EmpID = a.EmpID,
          Name = a.LastNm + ", " + a.FirstNm + ", " + a.MiddleNm,
          JobGradeDesc = c.JobGrdDesc,
          ShftNm = d.ShftNm,
          DayType = e.DayNm,
          LogDT = b.LogDt,
          LogIn = b.LogIn,
          LogOut = b.LogOut,
          Absent = b.AbsDay,
          Work = b.WorkHr,
          Late = b.LateHr,
          Overtime = b.OTHr,
          Undertime = b.OTHr,
          Nightdiff = b.NDHr,
          NightPrem = b.NPHr,
          ApprovedOT = b.AppOT,
          ApprovedOB = b.AppOB,
          ApprovedCoa = b.AppCOA,
          ApprovedCs = b.AppCS,
          Exception = b.ExcptStatus
      }).OrderBy(x => x.EmpID);
     if(parameter.selectedEmp != "ALL")
          relevantVMObjects = relevantVMObjects.Where(x => x.EmpID == param.CustomParam_EmpID);
     IEnumerable<DatatablesViewModel> viewmodel = relevantVMObjects;
