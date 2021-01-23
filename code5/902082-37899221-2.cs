    public bool SaveChangesEx()
    {
        try
        {
            SaveChanges();
            return true;
        }
        catch (DbEntityValidationException exc)
        {
            // just to ease debugging
            foreach (var error in exc.EntityValidationErrors)
            {
                foreach (var errorMsg in error.ValidationErrors)
                {
                    // logging service based on NLog
                    Logger.Log(LogLevel.Error, $"Error trying to save EF changes - {errorMsg.ErrorMessage}");
                }
            }
            throw;
        }
        catch (DbUpdateException e)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"DbUpdateException error details - {e?.InnerException?.InnerException?.Message}");
            foreach (var eve in e.Entries)
            {
                sb.AppendLine($"Entity of type {eve.Entity.GetType().Name} in state {eve.State} could not be updated");
            }
            Logger.Log(LogLevel.Error, e, sb.ToString());
            throw;
        }
    }
