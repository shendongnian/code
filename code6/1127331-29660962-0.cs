    public void InsertOrUpdate(zRequest zrequest)
        {
            if (zrequest.RequestId == default(int)) {
            context.zFacility.Attach(zrequest); // state Unchanged for zFacility  
            // New entity
           context.zRequests.Add(zrequest);
                } else {
                // Existing entity
                context.Entry(zrequest).State = System.Data.Entity.EntityState.Modified;
            }
        }
