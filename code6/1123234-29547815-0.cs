    using (TransactionScope scope = new TransactionScope())
    {
    if (exists.Any())
    {
        batch = exists.First();
        batchID = batch.BatchID;
        if(batch.StatusID != 1) 
        {
           audit = CreateAudit(batchID, auditModel);
        }
        else
        {
           if (auditModel.EventTypeID == 16) 
           {
              audit = CreateAudit(batchID, auditModel);
           }
           else
           {
               var checkTrans = GetAllTransactions(batchModel.BatchID);
               if (checkTrans.Count() > 1)
               {
                   audit = CreateAudit(batchID, auditModel);
               }
           }
       }
    }
    else
    {
        batch = new Batch()
        {
            CreatedDate = batchModel.CreatedDate
        };
        db.Batches.InsertOnSubmit(batch);
        db.SaveChanges();
        batchID = batch.BatchID;
        audit = CreateAudit(batchID, auditModel);
    }
    batch.Reason = batchModel.Reason;
    db.Audit.InsertOnSubmit(audit);
    db.SaveChanges();
    scope.Complete();
    }
    return batch;
