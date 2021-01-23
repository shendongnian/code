    var projDetails = from r in entities.ProjekRumah
    join d in entities.StateDistricts on r.ProjekLocationID equals d.DistrictID
    join j in entities.ProjekJenis on r.ProjekTypeID equals j.TypeID
    join s in entities.ProjekStatus on r.ProjekStatusID equals s.StatusID
    join approvalDetails in entities.ProjekApproval on r.ProjekID equals approvalDetails.ProjekID into approvalDetailsGroup
    from a in approvalDetailsGroup.DefaultIfEmpty()
    select new ProjectDetailsDTO()
           {
            ProjekID = r.ProjekID,
            ProjekName = r.ProjekName,
            ProjekDistrictName = d.DistrictName,
            ProjekTypeName = j.TypeName,
            ProjekStatusName = s.StatusName,
            IsApprovalAccepted = a.IsApprovalAccepted ? "Approved" : "Draft",
            ProjekApprovalRemarks = a.ApprovalRemarks
    };
