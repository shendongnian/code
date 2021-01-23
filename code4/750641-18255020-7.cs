     public static HttpStatusErrors ToHttpStatusErrors(
          this DbEntityValidationException ex)
     {
          return new HttpStatusErrors {
              Header = "Validation Error",
              Details = ex.EntityValidationErrors
                          .Select(eve => eve.ToHttpStatusErrorDetails())
                          .ToList()
          };
     }
     public static IList<HttpStatusErrorDetails> ToHttpStatusErrorDetails(
          this DbEntityValidationResult eve)
     {
          return new HttpStatusErrorDetails {
            Header = String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                   eve.Entry.Entity.GetType().Name, eve.Entry.State)
            Details = eve.ValidationErrors
                         .ToErrorDescriptions()
          };
     }
