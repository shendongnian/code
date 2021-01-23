    var msg = new HttpStatusErrors();
    msg.Header = "Validation Error";
    msg.Details = new List<HttpStatusErrorDetails>();
    foreach (var eve in ex.EntityValidationErrors)
    {
        var detail = new HttpStatusErrorDetails()
        detail.Header = String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            eve.Entry.Entity.GetType().Name, eve.Entry.State);
        detail.Details = new List<string>();
        foreach (var ve in eve.ValidationErrors)
        {
            detail.Details.Add(String.Format("- Property: \"{0}\", Error: \"{1}\"",
                ve.PropertyName, ve.ErrorMessage));
        }
        msg.Details.Add(detail);
    }
