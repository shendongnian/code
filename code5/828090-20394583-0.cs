    // original db query, still returns IQueryable.
    var dbPurchaseOrders = from d in db.TrnPurchaseOrders
                             where d.MstBranch.Id == BranchId &&
                                   d.MstBranch.MstUser.Id == secure.GetCurrentUser();
    // change db query to local, in-memory object list
    var localPurchaseOrders = PurchaseOrders.ToList();
    // change the local db.TrnPurchaseOrders objects into your Models.TrnPurchaseOrder objects.
    // kept the d variable because I'm too lazy to change all lines of your code.
    var PurchaseOrders = from d in localPurchaseOrders
                             select new Models.TrnPurchaseOrder
                             {
                                 Id = d.Id,
                                 PeriodId = d.PeriodId,
                                 Period = d.MstPeriod.Period,
                                 BranchId = d.BranchId,
                                 Branch = d.MstBranch.Branch,
                                 PONumber = d.PONumber,
                                 POManualNumber = d.POManualNumber,
                                 //PODate = d.PODate.ToShortDateString(),
                                 PODate = d.PODate.ToShortDateString(), //<------
                                 SupplierId = d.SupplierId,
                                 Supplier = d.MstArticle.Article,
                                 TermId = d.TermId,
                                 Term = d.MstTerm.Term,
                                 RequestNumber = d.RequestNumber,
                                 //DateNeeded = d.DateNeeded.ToShortDateString(),
                                 DateNeeded = d.DateNeeded.ToString(), //<------
                                 Particulars = d.Particulars,
                                 RequestedById = d.RequestedById == null ? 0 : d.RequestedById.Value,
                                 RequestedBy = d.MstUser.FullName,
                                 IsClosed = d.IsClosed,
                                 PreparedById = d.PreparedById,
                                 PreparedBy = d.MstUser.FullName,
                                 CheckedById = d.CheckedById,
                                 CheckedBy = d.MstUser1.FullName,
                                 ApprovedById = d.ApprovedById,
                                 ApprovedBy = d.MstUser2.FullName,
                                 IsLocked = d.IsLocked,
                                 CreatedById = d.CreatedById,
                                 CreatedBy = d.MstUser3.FullName,
                                 //CreatedDateTime = d.CreatedDateTime.ToShortDateString(),
                                 CreatedDateTime = d.CreatedDateTime.ToString(),
                                 UpdatedById = d.UpdatedById,
                                 UpdatedBy = d.MstUser4.FullName,
                                 //UpdatedDateTime = d.UpdatedDateTime.ToShortDateString()
                                 UpdatedDateTime = d.UpdatedDateTime.ToString()
                             };
