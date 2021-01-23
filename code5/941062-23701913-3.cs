    _context.Configuration.ValidateOnSaveEnabled = false;
    var entry = ctx.Entry(nmToModify);
    var validationErrors = entry.Property(a => a.Name).GetValidationErrors();
    if (validationErrors.Count > 0)
        throw new DbEntityValidationException("An entity property is invalid.", 
            new DbEntityValidationResult[] { new DbEntityValidationResult(
                entry, validationErrors) });
                    
    entry.Property(a => a.Name).IsModified = true;
