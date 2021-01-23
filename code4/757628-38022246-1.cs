    using (var context = new Stc.LeadTracker.DataModel.Models.DBNameContext())
    {
        var newLead = new DataModel.Models.LeadRequest();
        newLead.FormId = (int)formId;
        newLead.Request = queryString;
        newLead.Success = true;
        newLead.RetryCount = 0;
        newLead.CreatedBy = nvCollection["iw"];
        newLead.CreatedDateTime = DateTime.Now;
        context.LeadRequests.Add(newLead);
        context.SaveChanges();
        leadId = newLead.LeadRequestId;
    }
