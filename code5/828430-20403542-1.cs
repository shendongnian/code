    var qry = MyDB.tblBranch
        .Where(a=>a.branchid==1)
        .Select(a => new
        {
            days = System.Data.Objects
                .EntityFunctions.DiffDays(a.ExitDate,a.EnterDate)
        }
        .Where(d => d.days.HasValue)
        .Select(d => d.Value);
    DataTable dt = qry.ToDataTable();
