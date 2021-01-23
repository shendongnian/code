    var msg = new HttpStatusErrors();
    msg.Header = "Validation Error";
    msg.Details =
        ex.EntityValidationErrors
          .Select(eve => new HttpStatusErrorDetails 
                 {
                    Header = String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State)
                    Details = eve.ValidationErrors
                             .Select(ve => String.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage))
                             .ToList()
           })
           .ToList();
