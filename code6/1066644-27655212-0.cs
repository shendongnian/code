        List<PMAST> lstPmast = new List<PMAST>();
        lstPmast.Add(new PMAST() { EmpId = 0, PCODE = "--Select--", PNAME = "--Select--" });
        var GetEmployeeLst = (from d in db.PMASTs
             where d.CNO == iCNO && d.Isdeleted != true
             select new
             {
                EmpId = d.EmpId,
                PCODE = d.PCODE,
                PNAME = d.PNAME
        }).ToList();
        lstPmast.AddRange(GetEmployeeLst);
