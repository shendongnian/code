    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
    {
       foreach (var e in ex.EntityValidationErrors)
       {
          //check the ErrorMessage property
       }
    }
