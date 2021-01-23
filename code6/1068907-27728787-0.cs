     List<CTRAC.WebApi.Models.Organization> Organizations = (from acct in AcctWithChild    
             join allOrg in dc.Organizations on acct.ID equals allOrg.AccountID??0
                           let MYID=allOrg.Field<Int?>("AccountID")
                           where MYID.HasValue
                           select new CTRAC.WebApi.Models.Organization { Name = allOrg.vc_BusinessName, OrganizationID = allOrg.OrganizationId,Return990_Id=5, EfileSubmissionDate=acct.TrialBegin.Value }).ToList();
