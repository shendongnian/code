         Entities DBContext = new Entities();
        
            var d = DBContext.StudentTableName.Where(x => x.stname == "Stock").FirstOrDefault();
            if(d!= null)
            {
            d.Id = "345";
            DBContext.StudentTableName.ApplyCurrentValues(d);
            //Need to Include Audit Logging before  save, or can override save function.
            var entrList = DBContext.ObjectStateManager.GetObjectStateEntries(EntityState.Modified);
            foreach (var stateEntry in entrList)
            {
                var currentValues = stateEntry.CurrentValues;
                var originalValues = stateEntry.OriginalValues;
                var modifiedProperties = stateEntry.GetModifiedProperties();
                foreach (string modifiedProperty in modifiedProperties)
                {
                    var currentValue = currentValues.GetValue(currentValues.GetOrdinal(modifiedProperty));
                    var originalValue = originalValues.GetValue(originalValues.GetOrdinal(modifiedProperty));
                    if (!originalValue.Equals(currentValue))
                    {
                        //Perform the logging operation
                    }
                }
            }
            // Audit Logging Performed
            DBContext.SaveChanges();
    }
