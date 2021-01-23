    catch (DbEntityValidationException exDbEntityValidationException)
    {
       DbEntityValidationException exval = exDbEntityValidationException;
    
       StringBuilder sb = new StringBuilder();
    
       foreach (var excep in exval.EntityValidationErrors)
       {
           sb.AppendFormat("YourField: {0} {1}",((YourEntityType)excep.Entry.Entity).YourField, Environment.NewLine);
    
           excep.ValidationErrors.ToList().ForEach(v => sb.AppendFormat("   Field: {0} -  {1}{2}", v.PropertyName, v.ErrorMessage, Environment.NewLine));
       }
    
          System.Diagnostics.Debug.Print(sb.ToString());
    }
